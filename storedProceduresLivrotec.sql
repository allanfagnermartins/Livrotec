use scriptLivrotec;

Delimiter $$

Drop Procedure if Exists infoLivros$$
Create Procedure infoLivros(vISBN varchar(20))
begin
	Select nm_livro, nm_isbn, nm_caminho_foto_livro, qt_livro, ds_sinopse_livro from livro where nm_isbn = vISBN;
end$$

Drop Procedure if Exists listarLivros$$
Create Procedure listarLivros()
begin
	Select * from livro order by nm_isbn;
end$$

Drop Procedure if Exists listarLivrosPessoa$$
Create Procedure listarLivrosPessoa(vEmail varchar(200))
begin
	select * from livro l left join lugar_fila lf on (l.nm_isbn = lf.nm_isbn) where nm_email_usuario = vEmail or l.nm_isbn in (select nm_isbn from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null and ic_roubado = false);
end$$

Drop Procedure if Exists listarLivrosNaoPessoa$$
Create Procedure listarLivrosNaoPessoa(vEmail varchar(200))
begin
	select * from livro where nm_isbn not in (select nm_isbn from lugar_fila where nm_email_usuario = vEmail) and nm_isbn not in (select nm_isbn from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null);
end$$

Drop Procedure if Exists contarFila$$
Create Procedure contarFila(vISBN varchar(20))
begin
	Select count(*) from lugar_fila where nm_isbn = vISBN;
end$$

Drop Procedure if Exists checarFilaPessoa$$
Create Procedure checarFilaPessoa(vEmail varchar(200), vISBN varchar(20))
begin
	Select * from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
end$$

Drop Procedure if Exists checarEmprestimoPessoa$$
Create Procedure checarEmprestimoPessoa(vEmail varchar(200))
begin
	Select * from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null;
end$$

Drop Procedure if Exists icEmprestimoPessoa$$
Create Procedure icEmprestimoPessoa(vEmail varchar(200))
begin
	Select count(*) from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null;
end$$

Drop Procedure if Exists icEmprestimoLivro$$
Create Procedure icEmprestimoLivro(vEmail varchar(200), vISBN varchar(200))
begin
	Select count(*) from emprestimo where nm_email_usuario = vEmail and nm_isbn = vISBN and dt_devolucao_efetiva_emprestimo is null;
end$$

Drop Procedure if Exists deletarFilaPessoa$$
Create Procedure deletarFilaPessoa(vEmail varchar(200), vISBN varchar(20))
begin
	Declare lugar int;
	declare email text;
	declare isbn text;
	declare contagemFilaPrimeiro int;
	declare dataEfetiva date;
	Select cd_lugar_fila into lugar from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	Delete from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	Update lugar_fila set cd_lugar_fila = cd_lugar_fila-1 where nm_isbn = vISBN and lugar <= cd_lugar_fila;
end$$

Drop Procedure if Exists deletarFilaChecar$$
Create Procedure deletarFilaChecar(vEmail varchar(200), vISBN varchar(20))
begin
	declare dataEfetiva date;
	declare lugar int;
	Select cd_lugar_fila into lugar from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	Delete from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	Update lugar_fila set cd_lugar_fila = cd_lugar_fila-1 where nm_isbn = vISBN and lugar <= cd_lugar_fila;
end$$

Drop Procedure if Exists inserirFilaPessoa$$
Create Procedure inserirFilaPessoa(vEmail varchar(200), vISBN varchar(20))
begin
	Declare lugar int default 1;
	declare email text;
	declare isbn text;
	declare contagemFilaPrimeiro int;
	declare dataEfetiva date;
	Select max(cd_lugar_fila)+1 into lugar from lugar_fila where nm_isbn = vISBN;
	if lugar is null then
		set lugar = 1;
	end if;
	Insert into lugar_fila values (vEmail, vISBN, lugar, now());
	call CriarEmprestimo(vEmail, vISBN);
end$$

Drop Procedure if Exists inserirFilaChecar$$
Create Procedure inserirFilaChecar(vEmail varchar(200), vISBN varchar(20))
begin
	Declare lugar int default 1;
	declare email text;
	declare dataEfetiva date;
	Select max(cd_lugar_fila)+1 into lugar from lugar_fila where nm_isbn = vISBN;
	if lugar is null then
		set lugar = 1;
	end if;
	Insert into lugar_fila values (vEmail, vISBN, lugar);
	call CriarEmprestimo(vEmail, vISBN);
end$$


Drop Procedure if Exists VerificarUsuarioFila$$
Create Procedure VerificarUsuarioFila(vEmail varchar(200), vISBN varchar(20))
begin
	declare ComLivro bool;
    declare InscritoFila bool;
	select count(*) into InscritoFila from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	select count(*) into ComLivro from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null;
    select InscritoFila, ComLivro;
end$$


Drop Procedure if Exists LoginValido$$
Create Procedure LoginValido(vEmail varchar(200), vSenha varchar(64))
begin
	select count(*) from usuario where nm_email_usuario = vEmail and nm_senha_usuario = vSenha;
end$$

Drop Procedure if Exists VerificarAdmin$$
Create Procedure VerificarAdmin(vEmail varchar(200))
begin
	select count(*) from usuario where cd_tipo_usuario = 1 and nm_email_usuario =  vEmail;
end$$

Drop Procedure if Exists PrimeiroLugar$$
Create Procedure PrimeiroLugar(vEmail varchar(200))
begin
	declare contagemFilaPrimeiro int;
	declare isbn text;
	select count(*) into contagemFilaPrimeiro from lugar_fila where nm_email_usuario = vEmail and cd_lugar_fila = 1;
	while 0<contagemFilaPrimeiro do
	set contagemFilaPrimeiro = contagemfilaPrimeiro - 1;
	select nm_isbn into isbn from lugar_fila where nm_email_usuario = vEmail and cd_lugar_fila = 1 LIMIT contagemFilaPrimeiro,1;
	call deletarFilaPessoa (vEmail, isbn);
	call inserirFilaPessoa (vEmail, isbn);
	end while;
end$$


Drop Procedure if Exists CriarEmprestimo$$
Create Procedure CriarEmprestimo(vEmail varchar(200), vISBN varchar(200))
begin
    declare codigo int default 1;
	declare lugar int;
	declare quantidade int;
	declare qtEmprestimo int;

	select cd_lugar_fila into lugar from lugar_fila where nm_email_usuario = vEmail and nm_isbn = vISBN;
	if lugar=1 then
		select max(cd_emprestimo) into codigo from emprestimo;

		if codigo is null then
			set codigo = 0;
		end if;

		set codigo = codigo+1;
		
		select qt_livro into quantidade from livro where nm_isbn = vISBN;
		select count(*) into qtEmprestimo from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null;

		if quantidade>=1 and qtEmprestimo=0 then
			insert into emprestimo values (codigo, vISBN, vEmail, null, null, null, false);
			update livro set qt_livro = qt_livro-1 where nm_isbn = vISBN;
			call deletarFilaPessoa(vEmail, vISBN);
		end if;
	end if;
end$$

Drop Procedure if Exists ConfirmarEmprestimo$$
Create Procedure ConfirmarEmprestimo(vCodigo int)
begin
	update emprestimo set dt_emprestimo = curDate(), dt_devolucao_prevista_emprestimo =(select date_add(curdate(), interval 30 day)) where cd_emprestimo = vCodigo; 
end$$

Drop Procedure if Exists cancelarEmprestimo$$
Create Procedure cancelarEmprestimo(vCodigo int)
begin
	declare email text;
	select nm_email_usuario into email from emprestimo where cd_emprestimo = vCodigo;
	delete from emprestimo where cd_emprestimo = vCodigo;
	call automatizarEmprestimo(email);
end$$

Drop Procedure if Exists contarFilaPessoa$$
Create Procedure contarFilaPessoa(vEmail varchar(200))
begin
	select count(*) from livro l left join lugar_fila lf on (l.nm_isbn = lf.nm_isbn) where nm_email_usuario = vEmail or l.nm_isbn in (select nm_isbn from emprestimo where nm_email_usuario = vEmail and dt_devolucao_efetiva_emprestimo is null);
end$$

Drop Procedure if Exists listarEmprestimos$$
Create Procedure listarEmprestimos()
begin
	Select * from emprestimo order by dt_emprestimo asc;
end$$

Drop Procedure if Exists infoEmprestimo$$
Create Procedure infoEmprestimo(vCodigo varchar(200))
begin
	Select cd_emprestimo, nm_isbn, nm_email_usuario, dt_emprestimo, dt_devolucao_prevista_emprestimo, dt_devolucao_efetiva_emprestimo, ic_roubado from emprestimo where cd_emprestimo = vCodigo;
end$$

Drop Procedure if Exists checarFimEmprestimo$$
Create Procedure checarFimEmprestimo(vCodigo varchar(200))
begin
	declare dataEfetiva date;	
	declare EmprestimoAcabou bool;

	Select dt_devolucao_efetiva_emprestimo into dataEfetiva from emprestimo where cd_emprestimo = vCodigo;

	if dataEfetiva is null then
		set EmprestimoAcabou = 0;
		Select EmprestimoAcabou;

	else
		set EmprestimoAcabou = 1;
		Select EmprestimoAcabou;
	end if;
		
end$$

Drop Procedure if Exists confirmarDevolucao$$
Create Procedure confirmarDevolucao(vCodigo varchar(200))
begin
	declare isbn text;
	declare email text;
	select nm_email_usuario into email from emprestimo where cd_emprestimo = vCodigo;
	update emprestimo set dt_devolucao_efetiva_emprestimo = curDate() where cd_emprestimo = vCodigo;
	select nm_isbn into isbn from emprestimo where cd_emprestimo = vCodigo;
	update livro set qt_livro = qt_livro+1 where nm_isbn = isbn;
	call automatizarEmprestimo(email);
end$$

Drop Procedure if Exists confirmarDoacaoLivroExistente$$
Create Procedure confirmarDoacaoLivroExistente(vISBN varchar(200))
begin
	update livro set qt_livro = qt_livro+1 where nm_isbn = vISBN;
end$$

Drop Procedure if Exists confirmarDoacaoLivroNovo$$
Create Procedure confirmarDoacaoLivroNovo(vISBN varchar(200), vNome varchar(200), vSinopse text, vCaminho varchar(200))
begin
	insert into livro values (vIsbn, vNome, vSinopse, 1, vCaminho);
end$$

Drop Procedure if Exists infoEmprestimoSemCodigo$$
Create Procedure infoEmprestimoSemCodigo(vISBN varchar(200), vEmail varchar(200))
begin
	select cd_emprestimo, nm_isbn, nm_email_usuario, dt_emprestimo, dt_devolucao_prevista_emprestimo, dt_devolucao_efetiva_emprestimo, ic_roubado from emprestimo where nm_isbn = vISBN and nm_email_usuario = vEmail order by cd_emprestimo desc limit 1;
end$$

Drop Procedure if Exists calcDataEmprestimo$$
Create Procedure calcDataEmprestimo(vCodigo int)
begin
	select datediff(dt_devolucao_prevista_emprestimo, dt_emprestimo) from emprestimo where cd_emprestimo = vCodigo;
end$$

Drop Procedure if Exists codigoEmprestimo$$
Create Procedure codigoEmprestimo(vEmail varchar(200), vISBN varchar(200))
begin
	select cd_emprestimo from emprestimo where nm_isbn = vISBN and nm_email_usuario = vEmail order by cd_emprestimo desc limit 1;
end$$

Drop Procedure if Exists icRoubadosPessoa$$
Create Procedure icRoubadosPessoa(vEmail varchar(200))
begin
	select count(*) from emprestimo where nm_email_usuario = vEmail and ic_roubado = true;
end$$

Drop Procedure if Exists icConfirmado$$
Create Procedure icConfirmado(vCodigo varchar(200))
begin
	select count(*) from emprestimo where cd_emprestimo = vCodigo and dt_emprestimo is not null;
end$$

Drop Procedure if Exists excluirQtLivro$$
Create Procedure excluirQtLivro(vISBN varchar(200))
begin
    declare quantidade int;
    select qt_livro from livro where nm_isbn = vISBN into quantidade;



   if quantidade >= 1 then
        set quantidade =  quantidade -1;
        update livro set qt_livro = quantidade where nm_isbn = vISBN;
    end if;
end$$

Drop Procedure if Exists adicionarAtraso$$
Create Procedure adicionarAtraso(vCodigo varchar(200))
begin

	declare email text;
	declare quantidade int;
	declare dataprevista text;
	declare dias int;

	select nm_email_usuario into email from emprestimo where cd_emprestimo = vCodigo;
	select qt_atrasos_usuario into quantidade from usuario where nm_email_usuario = email;
	select dt_devolucao_prevista_emprestimo into dataprevista from emprestimo where cd_emprestimo = vCodigo;

	set dias = DATEDIFF(dataprevista, curDATE());

	if dias < 1 then
		update usuario set qt_atrasos = quantidade+1 where nm_email_usuario = email;
	end if;

	select count(*) from usuario where qt_atrasos_usuario = 0 or null and nm_email_usuario = email;

end$$

Drop Procedure if Exists emprestimoRoubado$$
Create Procedure emprestimoRoubado(vCodigo varchar(200))
begin
	declare email text;

	select nm_email_usuario into email from emprestimo where cd_emprestimo = vCodigo;
    update emprestimo set ic_roubado = true where cd_emprestimo = vCodigo;
	call adicionarRoubo(email);
end$$

Drop Procedure if Exists automatizarEmprestimo$$
Create Procedure automatizarEmprestimo(vEmail varchar(200))
begin
	declare codigo text;
	select nm_isbn into codigo from lugar_fila where nm_email_usuario = vEmail order by dt_entrada_fila asc limit 1;
	call CriarEmprestimo(vEmail, codigo);
end$$

Drop Procedure if Exists adicionarRoubo$$
Create Procedure adicionarRoubo(vEmail varchar(200))
begin
	declare quantidade int;
	declare situacao bool;

	select qt_roubos_usuario into quantidade from usuario where nm_email_usuario = vEmail;
	select ic_restrito_emprestimo into situacao from usuario where nm_email_usuario = vEmail;

	update usuario set qt_roubos_usuario = quantidade +1 where nm_email_usuario = vEmail;
	if situacao = false then
		update usuario set ic_restrito_emprestimo = true;
	end if;
end$$

