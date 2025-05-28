-- CRIANDO O BANCO DE DADOS
create database bdescola;

-- USANDO O BANCO DE DADOS
use bdescola;

-- CRANDO AS TABELAS DO BANCO
create table aluno (
	codAluno int primary key auto_increment,
    nome varchar(40) not null,
    idade int
);

create table responsavel (
	codResp int primary key auto_increment,
    codAluno int,
    nome varchar(40) not null,
    foreign key (codAluno) references aluno(codAluno)
);


-- CONSULTANDO AS TABELAS DO BANCO
select * from aluno;
select * from responsavel;

-- INSERINDO DADOS NAS TABELAS
insert into aluno (nome, idade) values
('Hugo', 15),
('José', 16),
('Luiz', 17),
('Donald', 20);

insert into responsavel (codAluno, nome) values
(1, 'Joaquina'),
(2, 'Maria'),
(3, 'Lurdes'),
(4, 'Creuza');

select t1.codResp as 'Código do responsável',
t1.nome as 'Nome do responsável',
t2.nome as 'Nome do aluno'
from responsavel t1
inner join aluno t2 on t1.codAluno = t2.codAluno;



