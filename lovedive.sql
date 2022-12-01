select * from emprestimo;

call ConfirmarEmprestimo(1);

update emprestimo set dt_devolucao_prevista_emprestimo = '2023-12-29' where cd_emprestimo = 1;

delete from emprestimo where cd_emprestimo = 3;

insert into emprestimo values (2, '8576862549', 'allanfagnermartins@gmail.com', '2023-11-29', '2023-12-29', null, false);

call calcDataEmprestimo(1);

call icRoubadosPessoa('allanfagnermartins@gmail.com');

call contarFila('85823507910');

call icConfirmado('1');

select datediff(dt_devolucao_prevista_emprestimo, dt_emprestimo) from emprestimo where cd_emprestimo =1;
