Drop schema if exists scriptLivrotec;
Create schema scriptLivrotec;
Use scriptLivrotec;

Create table livro
(
	nm_isbn varchar(10) not null,
	nm_livro VARCHAR(100) not null,
	ds_sinopse_livro text not null,
	qt_livro int,
	nm_caminho_foto_livro varchar(200) not null,	
	constraint pk_livro primary key (nm_isbn)
);

Create table tipo_usuario
(
	cd_tipo_usuario int,
	nm_tipo_usuario varchar(45) not null,
	constraint pk_tipo_usuario primary key (cd_tipo_usuario),
	constraint uk_nm_tipo_usuario unique (nm_tipo_usuario)
);

Create table usuario  
(
	nm_email_usuario varchar(200),
	cd_tipo_usuario int not null,
	nm_senha_usuario varchar(64) not null,
	nm_usuario varchar(150) not null,
	nm_telefone_usuario varchar(20) not null,
	nm_cpf_usuario varchar(20) not null,
	ic_restrito_emprestimo boolean,
	dt_bloqueio_restricao date,
	qt_atrasos_usuario int not null,
	qt_roubos_usuario int not null,
	constraint pk_usuario primary key (nm_email_usuario),
	constraint fk_tipo_usuario_usuario foreign key (cd_tipo_usuario) 
		references tipo_usuario(cd_tipo_usuario),
	constraint uk_nm_usuario unique (nm_usuario),
	constraint uk_telefone_usuario unique (nm_telefone_usuario),
	constraint uk_cpf_usuario unique (nm_cpf_usuario)
);

create table lugar_fila
(
	nm_email_usuario VARCHAR(200),
	nm_isbn VARCHAR(10),
	cd_lugar_fila INT,
	dt_entrada_fila DATETIME,
	CONSTRAINT pk_lugar_fila PRIMARY KEY (nm_email_usuario, nm_isbn),
	CONSTRAINT fk_usuario_lugar_fila FOREIGN KEY (nm_email_usuario) 
		REFERENCES usuario(nm_email_usuario),
	CONSTRAINT fk_livro_lugar_fila FOREIGN KEY (nm_isbn) 
		REFERENCES livro(nm_isbn)
);

create table emprestimo
(
	cd_emprestimo int,
	nm_isbn varchar(10),
	nm_email_usuario varchar(200),
	dt_emprestimo DATE,
	dt_devolucao_prevista_emprestimo DATE,
	dt_devolucao_efetiva_emprestimo DATE,
	ic_roubado BOOLEAN,
	CONSTRAINT pk_emprestimo PRIMARY KEY (cd_emprestimo),
	CONSTRAINT fk_emprestimo_livro FOREIGN KEY (nm_isbn) 
		REFERENCES livro (nm_isbn),
	CONSTRAINT fk_emprestimo_usuario FOREIGN KEY (nm_email_usuario) 
		REFERENCES usuario (nm_email_usuario)
);

create table doacao
(
	cd_doacao INT,
	nm_email_usuario VARCHAR(200),
	nm_isbn VARCHAR(10),
	dt_doacao DATE,
	CONSTRAINT pk_doacao PRIMARY KEY (cd_doacao),
	CONSTRAINT fk_doacao_usuario FOREIGN KEY (nm_email_usuario) 
		REFERENCES usuario (nm_email_usuario),
	CONSTRAINT fk_livro_doacao_livro FOREIGN KEY (nm_isbn) 
		REFERENCES livro (nm_isbn)
);

insert into tipo_usuario values (1,'Administrador');
insert into tipo_usuario values (2, 'Usu??rio Comum');

insert into usuario values('allanfagnermartins@gmail.com', 2, 'senha', 'Allan Fagner', '13988015435', '18928493716', false, null, 0, 0);
insert into usuario values('drianoreoul@gmail.com', 2, 'senha', 'Adriano Fraga', '13917189374', '1892568493716', false, null, 0, 0);
insert into usuario values('claradasilvabarriento@gmail.com', 2, 'senha', 'Clara Barriento', '13991325727','39675649836' , false, null, 0, 0);
insert into usuario values('evelyndasilva@gmail.com', 2, 'senha', 'Evelyn da Silva', '13973816251', '6791236451', false, null, 0, 0);
insert into usuario values('camilasantana@gmail.com', 2, 'senha', 'Camila Santana', '139917453', '27192172182', false, '2050-01-01', 0, 1);
insert into usuario values('sofiabretas@gmail.com', 1, 'senha', 'Sofia Bretas', '13985125135', '35141251200', false, null, 0, 0);

insert into livro values('8576862549','Os Garotos Corvos', 'Todo ano, na v??spera do Dia de S??o Marcos, Blue Sargent vai com sua m??e clarividente at?? uma igreja abandonada para ver os esp??ritos daqueles que v??o morrer em breve. Blue nunca consegue v??-los - at?? este ano, quando um garoto emerge da escurid??o e fala diretamente com ela. Seu nome ?? Gansey, e ela logo descobre que ele ?? um estudante rico da Academia Aglionby, a escola particular da cidade.',
1, '8576862549');

insert into livro values('8525068462', 'A Redoma de Vidro', 
'Publicado originalmente em 1963, esta edi????o, com tradu????o de Chico Mattoso, traz nova capa e desenhos da autora. Lan??ado semanas antes da morte de Sylvia, o livro ?? repleto de refer??ncias autobiogr??ficas, e a narrativa ?? inspirada nos acontecimentos do ver??o de 1952, quando Sylvia Plath tentou o suic??dio e foi internada em uma cl??nica psiqui??trica.',
1,'8525068462');

insert into livro values('858105045X', 'Salem', 
'Ambientado na cidadezinha de Jerusalems Lot, na Nova Inglaterra, o romance conta a hist??ria de tr??s forasteiros. Ben Mears, um escritor que viveu alguns anos na cidade quando crian??a e est?? disposto a acertar contas com o pr??prio passado; Mark Petrie, um menino obcecado por monstros e filmes de terror; e o Senhor Barlow, uma figura misteriosa que decide abrir uma loja na cidade.',
1, '858105045X');

insert into livro values('8594540183', 'Frankenstein', 
'O brilhante e pouco ortodoxo doutor Victor Frankestein trabalha na cria????o de um monstro com partes de diferentes corpos humanos. Ap??s ser rejeitada pelo criador, a criatura escapa e passa a agir com uma violenta sede de vingan??a.',
1,'8594540183');
insert into livro values('6586490294','O morro dos ventos uivantes', 
'Emily Bront?? nasceu em 1818 em Yorkshire, no interior da Inglaterra. Em vida, foi obrigada a esconder seu g??nero sob o pseud??nimo masculino Ellis Bell para que pudesse publicar suas obras. Das tr??s irm??s Bront??, Emily ?? a mais velha e tamb??m a de biografia mais misteriosa: embora a maior parte de seus di??rios tenha sido queimada, ela ganhou fama de ter uma personalidade reclusa e obscura. Emily morreu de tuberculose um ano ap??s a publica????o deste que ?? seu ??nico romance, e jamais descobriu que se tornou um dos maiores nomes da literatura mundial.',
2,'6586490294');
insert into livro values('8582350791','De volta aos quinze', 
'Ao ligar seu antigo computador, a protagonista ?? transportada para o primeiro dia no colegial, quando tinha 15 anos. Agora, ela vai tentar consertar a vida de todos ao seu redor, mas cada mudan??a no passado impacta o futuro de todos ??? e nem sempre para melhor"',
10,'8582350791');
insert into livro values('8501112429', 'Assassins Creed Origins', 
'Bayek sempre soube que seu destino estava em Siu??. Ele se tornar?? protetor da cidade, assim como o pai. Mas, quando um mensageiro misterioso chega ?? cidade, sua espera pac??fica chega ao fim.
O protetor parte imediatamente ap??s receber a mensagem, deixando para tr??s um rastro de perguntas e incertezas. Bayek ent??o inicia uma jornada em busca de respostas. Enquanto ele segue o Nilo em sua procura, por todo o pa??s uma conspira????o se desenrola.',
1,'8501112429');


