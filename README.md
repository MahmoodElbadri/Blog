
# ✨ ASP.NET Core Blog Platform

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-6.0+-512BD4?logo=dotnet)


![EF Core](https://img.shields.io/badge/Entity_Framework-7.0-512BD4)

A feature-rich blog platform built with modern web technologies, offering a premium content management experience with the elegant Bootstrap Lux theme.

## 🌟 Key Features

### 🎨 Frontend
- **Lux-Themed UI** - Premium Bootstrap 5 styling
- **Responsive Design** - Fully mobile-optimized
- **Interactive Elements** - AJAX-powered likes/comments
- **Rich Text Editor** - Froala WYSIWYG for post creation

### 🔒 Authentication
- Role-based access control (Admin/User)
- Secure password hashing
- Profile management
- Social login integration (optional)

### 🛠️ Admin Features
- Post management dashboard
- Tag categorization system
- User administration
- Analytics dashboard

## 📦 Technology Stack

| Category          | Technologies                          |
|-------------------|---------------------------------------|
| **Backend**       | ASP.NET Core 9, Entity Framework Core |
| **Frontend**      | Bootstrap 5 (Lux), JavaScript         |
| **Database**      | SQL Server                            |
| **Authentication**| ASP.NET Identity                      |
| **Editor**        | Froala WYSIWYG                        |



## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server 2019+

### Installation
1. Clone repository:
   ```bash
   git clone https://github.com/yourusername/blog-platform.git
   cd blog-platform
   ```

2. Configure database:
   ```bash
   dotnet ef database update
   ```

3. Seed initial data (optional):
   ```bash
   dotnet run seed
   ```

4. Launch application:
   ```bash
   dotnet run
   ```

## 📂 Project Structure

```
BlogPlatform/
├── Controllers/         # MVC controllers
├── Models/              # Domain and view models
├── Views/               # Razor views
├── Services/            # Business logic
├── Data/                # Database context
├── wwwroot/             # Static assets
│   ├── css/             # Custom styles
│   ├── js/              # Client scripts
│   └── lib/             # Third-party libraries
└── Migrations/          # EF Core migrations
```

## 🛠️ Development

### Building
```bash
dotnet build
```

### Code Style
Follows Microsoft's [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
