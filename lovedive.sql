select * from usuario;
select * from emprestimo;

call cadastrarUsuario ('josevictor@gmail.com','senha','José Victor','13988764202','39267819278');

call adicionarAtraso(1);

call editarUsuario ( 'allanfagnermartins@gmail.com', null, null, null,'67394672');

select ic_restrito_emprestimo from usuario where nm_email_usuario = 'allanfagnermartins@gmail.com';

select nm_email_usuario from usuario order by nm_email_usuario;