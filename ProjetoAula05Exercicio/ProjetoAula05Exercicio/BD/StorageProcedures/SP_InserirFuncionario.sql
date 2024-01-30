﻿CREATE PROCEDURE SP_InserirFuncionario
	@NOME			VARCHAR(100),	--ENTRADA
	@MATRICULA		VARCHAR(10),	--ENTRADA
	@CPF			VARCHAR(11)		--ENTRADA
AS
DECLARE
	@FUNCIONARIO_ID		UNIQUEIDENTIFIER

BEGIN
	
	--GERANDO UM ID PARA O FUNCIONARIO
	SET @FUNCIONARIO_ID = NEWID();

	--ABRINDO UMA TRANSAÇÃO NO BANCO DE DADOS
	BEGIN TRANSACTION;

	--GRAVANDO OS DADOS DO CLIENTE
	INSERT INTO FUNCIONARIO(ID, NOME, MATRICULA, CPF)
	VALUES(@FUNCIONARIO_ID, @NOME, @MATRICULA, @CPF);

	--FINALIZANDO A TRANSAÇÃO
	COMMIT;

END;
GO