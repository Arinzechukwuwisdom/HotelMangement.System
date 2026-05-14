
# Hotel Management System

A scalable and secure Hotel Management System built with **ASP.NET Core Web API**, designed to manage hotel operations such as room booking, customer management, reservations, authentication, and hotel services.

This project demonstrates backend development concepts including:

* RESTful API development
* Clean architecture practices
* Entity Framework Core
* Dependency Injection
* JWT Authentication
* Exception Handling Middleware
* Validation
* Repository Pattern
* Docker containerization

---

## 🚀 Features

* 🔐 JWT Authentication & Authorization
* 👤 User and Customer Management
* 🏨 Room Management
* 📅 Reservation & Booking System
* 💳 Payment/Transaction Handling
* 🧾 DTOs and Manual Mapping
* ✅ Fluent Validation
* ⚠️ Global Exception Handling Middleware
* 🗄️ Entity Framework Core with SQL Server
* 🐳 Docker Support
* 📚 Swagger API Documentation

---

## 🛠️ Technologies Used

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **JWT Bearer Authentication**
* **Docker**
* **Swagger/OpenAPI**
* **FluentValidation**

---

## 📂 Project Structure

```bash
HotelMangement.System
│
├── Controllers
├── Services
├── Repositories
├── Models
├── DTOs
├── Middleware
├── Validators
├── Data
├── Migrations
├── Extensions
├── Dockerfile
└── Program.cs
```

---

## ⚙️ Getting Started

### Prerequisites

Make sure you have the following installed:

* [.NET SDK](https://dotnet.microsoft.com/)
* [SQL Server](https://www.sqlserver.com/)
* [Docker](https://www.docker.com/) *(optional)*

---

## 🔧 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Arinzechukwuwisdom/HotelMangement.System.git
```

### 2. Navigate into the Project

```bash
cd HotelMangement.System
```

### 3. Configure Database Connection

Update your `appsettings.json` file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=HotelManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 🗄️ Run Database Migrations

```bash
dotnet ef database update
```

---

## ▶️ Run the Application

```bash
dotnet run
```

The API should start running on:

```bash
https://localhost:5001
```

or

```bash
http://localhost:5000
```

---

## 📘 Swagger Documentation

After running the application, access Swagger UI:

```bash
https://localhost:5001/swagger
```

---

## 🐳 Running with Docker

### Build Docker Image

```bash
docker build -t hotelmanagementapi .
```

### Run Docker Container

```bash
docker run -d -p 8080:80 hotelmanagementapi
```

---

## 🔐 Authentication

This API uses **JWT Authentication**.

After login/register, include the generated token in your request headers:

```bash
Authorization: Bearer your_token_here
```

---

## 📌 API Endpoints (Sample)

| Method | Endpoint             | Description   |
| ------ | -------------------- | ------------- |
| GET    | `/api/rooms`         | Get all rooms |
| POST   | `/api/rooms`         | Create a room |
| POST   | `/api/auth/login`    | User login    |
| POST   | `/api/auth/register` | Register user |
| POST   | `/api/bookings`      | Book a room   |
| GET    | `/api/bookings`      | Get bookings  |

---

## 🧪 Testing

Run tests using:

```bash
dotnet test
```

---

## 📈 Future Improvements

* Email Notifications
* Online Payment Integration
* Role-Based Authorization
* Room Availability Calendar
* Caching with Redis
* CI/CD Pipeline Integration

---

## 🤝 Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch

```bash
git checkout -b feature-name
```

3. Commit your changes

```bash
git commit -m "Added new feature"
```

4. Push to your branch

```bash
git push origin feature-name
```

5. Open a Pull Request

---

## 📄 License

This project is open-source and available under the MIT License.

---

## 👨‍💻 Author

Developed by **Wisdom Ogbu**

GitHub Repository:
[HotelMangement.System Repository](https://github.com/Arinzechukwuwisdom/HotelMangement.System.git?utm_source=chatgpt.com)

