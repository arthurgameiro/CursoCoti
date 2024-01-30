﻿--SCRIPT PARA CRIAR A TABELA DE PRODUTO
CREATE TABLE PRODUTO(
	ID				UNIQUEIDENTIFIER	PRIMARY KEY,
	NOME			VARCHAR(150)		NOT NULL,
	PRECO			DECIMAL(10,2)		NOT NULL,
	QUANTIDADE		INTEGER				NOT NULL,
	CATEGORIA_ID	UNIQUEIDENTIFIER	NOT NULL,
	FOREIGN KEY(CATEGORIA_ID) REFERENCES CATEGORIA(ID));

GO
--CONSULTAR AS CATEGORIAS
SELECT * FROM CATEGORIA;
GO