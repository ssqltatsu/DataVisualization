drop table games cascade;
drop table level cascade;
drop table users cascade;
drop table items cascade;
drop table item_log cascade;
drop table gachas cascade;
drop table gacha_log cascade;
drop table events cascade;
drop table contents cascade;
drop table appearance cascade;

create table games(
id	serial,
title varchar,
genre varchar,
primary key(id)
);

create table users(
id serial,
name varchar,
sex varchar,
birthday timestamp without time zone,
primary key(id)
);

create table level(
u_id int,
game_id int,
level int,
foreign key (u_id) references users (id),
foreign key (game_id) references games (id)
);

create table gachas(
id serial,
name varchar,
game_id int,
primary key(id),
foreign key (game_id) references games (id) 
);

create table gacha_log(
u_id int,
gacha_id int,
day timestamp with time zone,
foreign key(u_id) references users(id),
foreign key(gacha_id) references gachas(id)
);

create table contents(
id serial,
name varchar,
rarity int,
primary key(id)
);

create table appearance(
gacha_id int,
cont_id int,
prob numeric,
foreign key(gacha_id) references gachas(id),
foreign key(cont_id) references contents(id)
);
