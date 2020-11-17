BACKEND

DESENVOLVIDO EM .NET CORE 3.0

EXECUÇÃO BACKEND
	- NECESSÁRIO VS2019
	- A APLICAÇÃO TRABALHA COM BANCO DE DADOS SQLSERVER
	- RODAR O ARQUIVO ScriptInicial.sql NO DIRETÓRIO >> \BACKEND\Src\VxTel.Infra\Scripts
	- APÓS ISSO REALIZAR O BUILD
	- DENTRO DO VISUAL STUDIO NO MENU TEST >  TESTEXPLORER OS TESTES SERÃO LISTADOS E PODERÃO SER EXECUTADOS TODOS DE UMA VEZ
	- O FONTE DOS TESTES SE ENCONTRA NO PROJETO VxTel.Tests
	- VERIFICAR A CONNECTION STRING DENTRO DO APPSETTINGS NA SEGUINTE CHAVE, A MESVA DEVE SERGUIR DE FORMA PARA SE CONECTAR NO SEU BANCO DE DADOS
		"ConnectionStrings": {
      "DefaultConnection": "Data Source = (LocalDb)\\MSSQLLocalDB; Database=VXTEL;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
		O ARQUIVO SE ENCONTRA DENTRO DO PROJETO VxTel.API
	
	- APÓS OS PASSOS REALIZADOS, A APLICAÇÃO PODE SER EXECUTADA
	
EXECUÇÃO FRONT-END

	- NECESSÁRIO ANGULAR INSTALADO NA MÁQUINA, PARA ESSE PROJETO FORAM UTILIZADAS AS SEGUINTES VERSÕES
Angular CLI: 9.1.12
Node: 12.16.1
OS: win32 x64

Angular: 9.1.12
... animations, cli, common, compiler, compiler-cli, core, forms
... language-service, localize, platform-browser
... platform-browser-dynamic, router
Ivy Workspace: Yes

Package                           Version
-----------------------------------------------------------
@angular-devkit/architect         0.901.12
@angular-devkit/build-angular     0.901.12
@angular-devkit/build-optimizer   0.901.12
@angular-devkit/build-webpack     0.901.12
@angular-devkit/core              9.1.12
@angular-devkit/schematics        9.1.12
@ngtools/webpack                  9.1.12
@schematics/angular               9.1.12
@schematics/update                0.901.12
rxjs                              6.5.5
typescript                        3.8.3
webpack                           4.42.0

	- EXECUTAR O COMANDO "NPM INSTALL" DENTRO DA PASTA DA SOLUÇÃO PARA RESTAURAR O NODEMODULES
	- VERIFICAR SE FRONT\VxTelSite\src\environments OS ARQUIVOS ENVIOREMENTS CONTÉM O ENDEREÇO DA API REFERENTE AOS PLANOS
	- EXECUTAR O COMANDO NG SERVE 


