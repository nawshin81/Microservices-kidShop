drop database if exists productService;
create database productService;
use productService;

create table product(
    id varchar(36) primary key not null,
    name varchar(100) not null,
    categoryId varchar(36) not null,
    categoryName varchar(100) not null ,
    averageRating float not null default 0,
    numberOfRaters int not null default 0
);

create table category(
    categoryId varchar(36) primary key not null,
    categoryName varchar(100) not null
);
