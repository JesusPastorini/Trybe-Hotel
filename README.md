# 🏨 Projeto: Trybe Hotel

## ℹ️ Sobre o Projeto

O projeto Trybe Hotel consiste no desenvolvimento de uma API para controle de cidades, hotéis e quartos, que será utilizada em uma aplicação de booking de várias redes de hotéis. A API permitirá listar cidades, hotéis, inserir novas cidades e hotéis, além de manipular quartos de hotéis.

## 🛠️ Tecnologias e Habilidades

- **Plataforma Utilizada:** ASP.NET Core
- **Linguagem Utilizada:** C#
- **Banco de Dados:** SQL Server
- **Operações de Banco de Dados em uma API**
- **Desenvolvimento de Endpoints RESTful**
- **DTOs (Data Transfer Objects)**
- **Testes Unitários**

## 📋 Funcionalidades Implementadas

1. **Implementação das Models:**
   - Arquivos do diretório `/src/TrybeHotel/Models/`.
   - Implementação das models City, Hotel e Room.
   - Implementação do contexto do banco de dados.

2. **Endpoint GET /city:**
   - Método `GetCities()` no arquivo `/src/TrybeHotel/Controllers/CityController.cs`.
   - Lógica de interação com o banco de dados no método `GetCities()` do arquivo `/src/TrybeHotel/Repository/CityRepository.cs`.
   - Resposta no formato JSON contendo todas as cidades cadastradas.

3. **Endpoint POST /city:**
   - Método `PostCity()` no arquivo `/src/TrybeHotel/Controllers/CityController.cs`.
   - Lógica de interação com o banco de dados no método `AddCity()` do arquivo `/src/TrybeHotel/Repository/CityRepository.cs`.
   - Corpo da requisição no formato JSON com o nome da cidade.
   - Resposta no formato JSON com os dados da cidade recém-cadastrada.

4. **Endpoint GET /hotel:**
   - Método `GetHotels()` no arquivo `/src/TrybeHotel/Controllers/HotelController.cs`.
   - Lógica de interação com o banco de dados no método `GetHotels()` do arquivo `/src/TrybeHotel/Repository/HotelRepository.cs`.
   - Resposta no formato JSON contendo todos os hotéis cadastrados com o nome da cidade correspondente.

5. **Endpoint POST /hotel:**
   - Método `PostHotel()` no arquivo `/src/TrybeHotel/Controllers/HotelController.cs`.
   - Lógica de interação com o banco de dados no método `AddHotel()` do arquivo `/src/TrybeHotel/Repository/HotelRepository.cs`.
   - Corpo da requisição no formato JSON com o nome do hotel, endereço e ID da cidade.
   - Resposta no formato JSON com os dados do hotel recém-cadastrado, incluindo o nome da cidade.

6. **Endpoint GET /room/:hotelId:**
   - Método `GetRoomsByHotelId(int hotelId)` no arquivo `/src/TrybeHotel/Controllers/RoomController.cs`.
   - Lógica de interação com o banco de dados no método `GetRoomsByHotelId(int hotelId)` do arquivo `/src/TrybeHotel/Repository/RoomRepository.cs`.
   - Resposta no formato JSON contendo todos os quartos do hotel com o ID fornecido.

7. **Endpoint POST /room:**
   - Método `PostRoom()` no arquivo `/src/TrybeHotel/Controllers/RoomController.cs`.
   - Lógica de interação com o banco de dados no método `AddRoom()` do arquivo `/src/TrybeHotel/Repository/RoomRepository.cs`.
   - Corpo da requisição no formato JSON com o número do quarto, tipo e ID do hotel.
   - Resposta no formato JSON com os dados do quarto recém-cadastrado, incluindo o nome do hotel e da cidade.

8. **Endpoint DELETE /room/:roomId:**
   - Método `Delete(int roomId)` no arquivo `/src/TrybeHotel/Controllers/RoomController.cs`.
   - Lógica de interação com o banco de dados no método `DeleteRoom(int roomId)` do arquivo `/src/TrybeHotel/Repository/RoomRepository.cs`.
   - Remoção do quarto com o ID fornecido.

## 🔗 Diagrama de Entidade-Relacionamento (DER)

![Diagrama de Entidade-Relacionamento](src/derr.png)

## 🐳 Docker

Para auxiliar no desenvolvimento, utilize o Docker Compose para subir o serviço do banco de dados SQL Server. As credenciais de acesso são:
- **Server:** localhost
- **User:** sa
- **Password:** TrybeHotel12!
- **Database:** TrybeHotel

