create database academiaInteracao;
use academiaInteracao;



create table Cliente(
codigoC int not null primary key auto_increment,
nome varchar(100) not null,
CPF bigint not null,
telefone varchar(15) not null,
endereco varchar(120) not null
)Engine = InnoDB;



create table Funcionario(
codigoF int not null primary key auto_increment,
nome varchar(100) not null,
CPF bigint not null,
telefone varchar(15) not null,
endereco varchar(120) not null
)Engine = InnoDB;

create table Login(
codigoL int not null primary key auto_increment,
email varchar(100) not null,
senha varchar(100) not null
)Engine = InnoDB;

select*from Funcionario;