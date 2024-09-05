create database dbOUCR20240905

create table ProductsOUCR(

	id int primary key identity(1,1),
	NombreOUCR varchar(30) not null,
	DescripcionOUCR varchar(100),
	PrecioOUCR decimal(10,2) not null

)