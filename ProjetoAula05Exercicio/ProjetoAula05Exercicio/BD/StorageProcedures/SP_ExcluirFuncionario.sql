﻿CREATE PROCEDURE SP_ExcluirFuncionario
	@ID		UNIQUEIDENTIFIER -- ENTRADA

AS
BEGIN

	--ABRINDO UMA TRANSAÇÃO NO BANCO DE DADOS
	BEGIN TRANSACTION;

	--EXCLUINDO OS DADOS DO FUNICIONARIO
	DELETE	FROM FUNCIONARIO
	WHERE	ID = @FUNCIONARIO_ID;

	--FINALIZANDO A TRANSAÇÃO
	COMMIT;

END;
GO