# SerMais

## O que é o projeto?

Já imaginou uma plataforma web que possa criar portfólios para profissionais da área da psicologia?

É isso que o sistema Sermais faz, a partir de um cadastro simples, um profissional psicólogo poderá acessar a plataforma e criar um portfólio web totalmente gratuito, contendo com esse portfólio um sistema de agendamento de consultas.

Além disso, usuário podem acessar a plataforma e realizar uma consulta com algum profissional cadastrado na plataforma.

O projeto foi desenvolvido em ASPNET MVC .NET 6.0, utilizando Entity Framework e o modelo Coding First.


## Requisitos para o projeto

- Primeiro requisito essêncial é que tenha instalado em sua máquina a IDE Visual Studio com o pacote:  `ASP.NET e Desenvolvimento Web`
- É necessário ter o banco de dados [Microsoft SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- O projeto tem algumas depências internas, como o [Entity Framework](https://learn.microsoft.com/pt-br/ef/) e outro, que fazem a conexão com banco, envio de E-mail, etc. (certifique-se de quando clonar o projeto, verificar se essas estão ativas)
- Para instalação do banco com o Microsoft SQL Server e o EF instalados, no terminal do Visual Studio, execute o comando `update-database`, isso irá criar o banco e as tabelas via EntityFramework (certifique-se que sua String De conexão esteja configura de acordo com seu banco de dados)
- Para a realização do clone do repositório, precisará ter em sua máquina o Git, link para downlaod [Git](https://git-scm.com/downloads)


## Atualizações de instalação

- Agora será necessário realizar a clonagem do repositório `git clone https://github.com/WesleyRodrigues55/SerMais.git` via linha de comando ou alguma ferramenta.

- Após isso, acesse o projeto clonado `cd SerMais` ou em alguma IDE de sua preferência.

- Caso precise saber mais dos calendários sendo utilizados,p para marcação de consultas, acesse [FullCalendar](https://fullcalendar.io/docs/initialize-globals)


## Configuração

- Certifique-se de importar o script SQL no seu `Microsoft SQL server` e em seguida, utilizar sua string de conexão no arquivo `./appsettings.json` em `ConnectionStrings.DataBase=YOUR_STRING_CONNECTION`


## Requisitos do servidor

- Em `./Controllers/EmailController` há um método chamado `Smtp(MimeMessage message)`, altere a linha `client.Authenticate("YOUR EMAIL", "YOUR  KEY");` para seu e-mail e key. (pra isso deverá configurar um servidor SMPT para envio de e-mails e gerar uma chave de vinculação do e-mail para o serviço utilizado), poderá saber mais sobre isso em [Criar e usar senhas de app](https://support.google.com/mail/answer/185833?hl=pt-BR#zippy=) ou pelo [vídeo](https://www.youtube.com/watch?v=IWxwWFTlTUQ&ab_channel=MakersGroup)
