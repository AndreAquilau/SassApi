## API Sass Projeto Integrador UNESC-CACOAL

#### Install Framework SDK .Net 6 and ASP.NET Core Runtime 6

[Link Download .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

### Settings Variables .env
```.env
SECRET_TOKEN=*********************
//Data base postgresql
DATABASE_URL=User ID=******;Password=******;Host=localhost;Port=5432;Database=*****;Pooling=true;
```

### Install Packages Nuget
```cmd
	dotnet restore
```
### Run Migration
```cmd
	update-database
```

### Script Migrations
```SQL
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Clientes" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "Cpf" text NULL,
    "Endereco" text NULL,
    "Bairro" text NULL,
    "Cidade" text NULL,
    "Estado" text NULL,
    CONSTRAINT "PK_Clientes" PRIMARY KEY ("Id")
);

CREATE TABLE "Produtos" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "Descricao" text NULL,
    "Valor" double precision NOT NULL,
    CONSTRAINT "PK_Produtos" PRIMARY KEY ("Id")
);

CREATE TABLE "Usuarios" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "Email" text NOT NULL,
    "Senha" text NOT NULL,
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211201200159_create database', '6.0.0');

COMMIT;
```

### Use Routes

SaaApi

http://localhost:5002/login
Bodyraw (json)
json
{
  "Email": "andre@gmail.com",
  "Senha": "123"
}

Registrar-se
http://localhost:5002/signup
Bodyraw (json)
json
{
  "Nome": "André Da Silva",
  "Email": "andre@gmail.com",
  "Senha": "123"
}

Produto
FindAll
http://localhost:5002/produto
GET
FindById
http://localhost:5002/produto/1


POST
Create
http://localhost:5002/produto
Authorization
Bearer Token
Token
<token>
Bodyraw (json)
json
{
  "Nome": "Maçã",
  "Descricao": null,
  "Valor": 20
}

PUT
Update
http://localhost:5002/produto/1
Bodyraw (json)
json
{
  "Nome": "Banana",
  "Descricao": null,
  "Valor": 25
}

DEL
Delete
http://localhost:5002/produto/1

Cliente
GET
FindAll
http://localhost:5002/cliente

GET
FindById
http://localhost:5002/cliente/1

POST
Create
http://localhost:5002/cliente
Bodyraw (json)
json
{
  "Nome": "André Da Silva",
  "Cpf": "234.123.123-89",
  "Endereco": "Av. Copacabana",
  "Bairro": "Novo Cacoal",
  "Cidade": "Cacoal",
  "Estado": "Rodônia"
}

PUT
Update
http://localhost:5002/cliente/1
Bodyraw (json)
json
{
  "Nome": "André Da Silva",
  "Cpf": "234.123.123-89",
  "Endereco": "Av. Copa",
  "Bairro": "Novo",
  "Cidade": "Cacoal",
  "Estado": "Rodônia"
}
DEL
Delete
http://localhost:5002/cliente/1

### Start API
dotnet run
