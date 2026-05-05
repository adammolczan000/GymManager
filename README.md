# GymManager
GymManager API

GymManager API is a backend system for managing gym operations. It provides authentication, user management, and a membership system that allows tracking gym clients and their subscription plans.

The project is built as a REST API using ASP.NET Core and Entity Framework Core, with JWT-based authentication and role-based authorization.

Purpose

The goal of this project is to simulate a real-world gym management backend system that could be used by a gym application to:

manage users (clients and administrators)
handle authentication and authorization
manage membership plans and subscriptions
store and track active memberships
Features
Authentication and Authorization
User registration and login
Password hashing using BCrypt
JWT token authentication
Role-based access control (Admin / Client)
User Management
Users stored in SQLite database
Each user has email, password hash, and role
Membership System
Membership plans (e.g. monthly, yearly)
Members assigned to plans
Membership tracking with start and end dates
Database
SQLite database using Entity Framework Core
Automatic migrations
Local development database file: gym.db
Tech Stack
ASP.NET Core Web API (.NET 10)
Entity Framework Core
SQLite
JWT Authentication
BCrypt
Swagger (OpenAPI)
API Documentation

Swagger is available in development mode:

http://localhost:xxxx/swagger
Authentication Flow
Register user:
POST /api/auth/register
Login:
POST /api/auth/login
Receive JWT token and use it in requests:
Authorization: Bearer <token>
Example Endpoints
GET /api/auth/me – current user info
GET /api/auth/admin-only – admin-only endpoint
GET /api/auth/client-only – client-only endpoint
Project Structure
Controllers – API endpoints
Models – database entities
DTOs – request/response models
Data – DbContext (EF Core)
Repositories – data access layer
Authentication – JWT logic
