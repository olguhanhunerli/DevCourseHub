<p align="center">
  <h1 align="center">🚀 DevCourseHub API</h1>
  <p align="center">
    Modern online learning platform backend built with <b>.NET 8</b> and <b>Clean Architecture</b>
  </p>
</p>

<p align="center">
  <img alt=".NET" src="https://img.shields.io/badge/.NET-8.0-purple" />
  <img alt="Architecture" src="https://img.shields.io/badge/Architecture-Clean-blue" />
  <img alt="Database" src="https://img.shields.io/badge/Database-PostgreSQL-336791" />
  <img alt="ORM" src="https://img.shields.io/badge/ORM-EF%20Core-green" />
  <img alt="Mapper" src="https://img.shields.io/badge/Mapper-AutoMapper-orange" />
  <img alt="Auth" src="https://img.shields.io/badge/Auth-JWT-red" />
</p>

---

## 📖 Overview

DevCourseHub API is a scalable backend for an online learning platform built with .NET 8 and Clean Architecture.

---

## ✨ Features

- JWT Authentication & Authorization  
- Course Management  
- Section & Lesson Structure  
- Enrollment System  
- Progress Tracking  
- Review & Rating System  
- Pagination & Filtering  
- Clean Architecture  

---

## 🛠️ Tech Stack

- .NET 8  
- Entity Framework Core  
- PostgreSQL  
- AutoMapper  

---

## 🏗️ Architecture

```bash
DevCourseHub/
├── Domain
├── Application
├── Infrastructure
├── API
```

---

## 🔗 API Endpoints

- /api/auth  
- /api/courses  
- /api/sections  
- /api/lessons  
- /api/enrollments  
- /api/progress  
- /api/reviews  

---

## 🔐 Default Users

Admin  
admin@devcoursehub.com / Admin123*

Instructor  
instructor@devcoursehub.com / Instructor123*

Student  
student@devcoursehub.com / Student123*

---

## ⚡ Getting Started

```bash
git clone https://github.com/your-username/devcoursehub.git
cd devcoursehub
dotnet ef database update
dotnet run
```

Swagger:  
https://localhost:5001/swagger

---

## 🧠 Key Concepts

- Clean Architecture  
- Repository + Unit of Work  
- DTO & AutoMapper  
- JWT Authentication  

---

## 🔒 Security

Sensitive data is NOT stored in repo.  
Use local config or environment variables.

---

## 🤝 Contributing

1. Fork  
2. Create branch  
3. Commit  
4. PR  

---

## 👨‍💻 Author

Olguhan Hünerli
