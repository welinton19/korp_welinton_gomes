
Korp_Teste_WelintonGomes
Sistema de Emissão de Notas Fiscais — Desafio Técnico Korp ERP
Sobre o Projeto
Sistema completo de emissão de notas fiscais desenvolvido com arquitetura de microsserviços, utilizando C# no backend, Angular no frontend e PostgreSQL como banco de dados. Todo o ambiente é containerizado com Docker Compose.
Arquitetura
A solução é composta por quatro serviços independentes:
    • StockService — gerenciamento de produtos e controle de estoque
    • BillingService (Nota Fiscal API) — gestão e emissão de notas fiscais
    • API Gateway (YARP) — roteamento centralizado das requisições
    • Frontend (Angular) — interface de usuário servida via Nginx

A comunicação entre BillingService e StockService é feita internamente via Refit (HTTP tipado). O Angular nunca acessa os serviços diretamente, apenas o Gateway.
Pré-requisitos
    • Docker Desktop instalado e rodando
    • Git
Como Rodar
    1. Clone o repositório:
git clone https://github.com/welinton19/Korp_Teste_WelintonGomes.git
    2. Entre na pasta raiz do projeto:
cd Korp_Teste_WelintonGomes
    3. Suba todos os containers:
docker-compose up --build
    4. Acesse o sistema em:
http://localhost:4200
Endereços dos Serviços
Serviço
URL
Descrição
Frontend
http://localhost:4200
Interface Angular
API Gateway
http://localhost:5000
Ponto de entrada das APIs
StockService Swagger
http://localhost:5001/swagger
Docs da API de Estoque
BillingService Swagger
http://localhost:5002/swagger
Docs da API de Notas Fiscais
PostgreSQL
localhost:5432
Banco de dados

Funcionalidades
    • Cadastro e listagem de produtos com controle de estoque
    • Cadastro de notas fiscais com múltiplos itens
    • Impressão de nota fiscal com atualização automática do estoque
    • Geração de PDF da nota fiscal diretamente no navegador
    • Feedback visual de erro quando um microsserviço está indisponível
    • Migrations aplicadas automaticamente na inicialização dos containers
Estrutura do Projeto
Korp_Teste_WelintonGomes/
├── docker-compose.yml
├── Init-db.sh
├── Korp_Teste_WelintonGomes/   ← StockService API
├── Stock.Application/
├── Stock.Infraestructure/
├── StockDomain/
├── Nota_Fiscal.API/            ← BillingService API
├── Nota_Fiscal.application/
├── Nota_Fiscal.Infrastructure/
├── Nota_Fiscal.Domain/
├── Service.Gateway/            ← API Gateway (YARP)
└── stock-front-end/            ← Frontend Angular

Autor
Welinton Gomes
batistawelinton54@gmail.com
Desafio Técnico — Korp ERP — Abril 2026
Repositório: github.com/welinton19/Korp_Teste_WelintonGomes
