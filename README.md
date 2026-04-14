🚀 Korp Teste — Welinton Gomes
Sistema de Emissão de Notas Fiscais (Desafio Técnico Korp ERP)
📌 Sobre o Projeto

Sistema completo de emissão de notas fiscais desenvolvido com arquitetura de microsserviços, utilizando:

Backend: C# (.NET)
Frontend: Angular
Banco de Dados: PostgreSQL
Containerização: Docker + Docker Compose

A aplicação foi projetada seguindo boas práticas de arquitetura moderna, separando responsabilidades e garantindo escalabilidade.

🧱 Arquitetura

A solução é composta por 4 serviços independentes:

🔹 StockService
Responsável pelo gerenciamento de produtos e controle de estoque
🔹 BillingService (API Nota Fiscal)
Responsável pela criação e emissão de notas fiscais
🔹 API Gateway (YARP)
Centraliza e roteia todas as requisições da aplicação
🔹 Frontend (Angular)
Interface do usuário, servida via Nginx
🔗 Comunicação entre serviços
O BillingService se comunica com o StockService via Refit (HTTP tipado)
O Frontend NÃO acessa diretamente os serviços
Todas as requisições passam obrigatoriamente pelo API Gateway

👉 Isso garante:

Maior segurança
Baixo acoplamento
Facilidade de manutenção
⚙️ Pré-requisitos

Antes de rodar o projeto, você precisa ter instalado:

✅ Docker Desktop
✅ Git
▶️ Como executar o projeto
# 1. Clone o repositório
git clone https://github.com/welinton19/Korp_Teste_WelintonGomes.git

# 2. Acesse a pasta do projeto
cd Korp_Teste_WelintonGomes

# 3. Suba os containers
docker-compose up --build
🌐 Acessos do Sistema
Serviço	URL	Descrição
Frontend	http://localhost:4200	Interface Angular
API Gateway	http://localhost:5000	Entrada única das APIs
StockService	http://localhost:5001/swagger	Documentação da API de Estoque
BillingService	http://localhost:5002/swagger	Documentação da API de Notas
PostgreSQL	localhost:5432	Banco de dados
✨ Funcionalidades
✔️ Cadastro e listagem de produtos com controle de estoque
✔️ Cadastro de notas fiscais com múltiplos itens
✔️ Atualização automática do estoque após emissão
✔️ Impressão de nota fiscal
✔️ Geração de PDF diretamente no navegador
✔️ Feedback visual quando serviços estão indisponíveis
✔️ Execução automática de migrações ao iniciar os containers
📁 Estrutura do Projeto
Korp_Teste_WelintonGomes/
│
├── docker-compose.yml
├── Init-db.sh
│
├── Korp_Teste_WelintonGomes/        # StockService
│   ├── Stock.Application/
│   ├── Stock.Infrastructure/
│   └── Stock.Domain/
│
├── Nota_Fiscal.API/                 # BillingService
│   ├── Nota_Fiscal.Application/
│   ├── Nota_Fiscal.Infrastructure/
│   └── Nota_Fiscal.Domain/
│
├── Service.Gateway/                 # API Gateway (YARP)
│
└── stock-front-end/                 # Frontend Angular
👨‍💻 Autor

Welinton Gomes
📧 batistawelinton54@gmail.com

📅 Contexto

Desafio Técnico — Korp ERP
Abril de 2026

🔗 Repositório

👉 https://github.com/welinton19/Korp_Teste_WelintonGomes

💡 Considerações

Este projeto demonstra conhecimentos em:

Arquitetura de microsserviços
API Gateway (YARP)
Comunicação entre serviços (Refit)
Docker e orquestração com Docker Compose
Integração frontend/backend
Boas práticas de organização e separação de camadas

🔥 Projeto pronto para evolução futura com:

Autenticação (JWT)
Observabilidade (logs centralizados)
Deploy em nuvem (Azure / AWS)
CI/CD
