# Vendor Access Governance

Internal web application for managing **access requests** to company systems by external workers and vendors.  
This project is my way of practicing how to build real-world enterprise applications with **C#, ASP.NET Core MVC, EF Core, and SQL Server**, following clean architecture and software engineering principles.

> Goal: simulate a realistic enterprise app, with a clear domain model, layered architecture, and a traceable access request workflow.

---

## What this application does

Typical scenario: a company collaborates with external vendors and consultants. To let them work on internal projects, you need:

- formal, traceable access requests  
- explicit approvals  
- visibility on active access

This application focuses on that process, starting from the **highest‑priority user story**:

> “As an internal contact, I want to create and view access requests for vendors and external workers, so that I can initiate and monitor the authorization process.”

---

## Current domain model

The core domain is represented by **plain C# classes**, with no framework dependencies:

- `ExternalWorker`  
  Represents an individual working externally on behalf of a vendor (consultant, technician, etc.).

- `Vendor`  
  Represents the vendor company providing services or personnel.

- `AccessRequest`  
  The central entity of the domain: a formal request for access to one or more internal systems/projects, linking `ExternalWorker`, `Vendor`, and operational information (project, reason, request date, and so on).

Starting from these three entities, I’m incrementally extending the model (projects, roles, request states, etc.) with a domain‑driven mindset.

---

## Current status: User Story 1

**Implemented feature:** create and view access requests.

- Form to **create a new `AccessRequest`**:
  - select/associate an `ExternalWorker` and a `Vendor`  
  - enter request details (project, reason, operational notes, etc.)
- Persistence to **SQL Server** via **Entity Framework Core**:
  - dedicated `DbContext`  
  - initial migration to create tables related to `ExternalWorker`, `Vendor`, `AccessRequest`
- View to **list existing access requests**:
  - shows saved requests  
  - surfaces key information for admins and internal contacts

This user story was chosen as the first one after a brief software‑engineering style analysis: before implementing advanced role management, complex workflows or reporting, you need a robust flow to **insert and read** access requests.

---

## Tech stack

- **Language:** C#
- **Web framework:** ASP.NET Core MVC  
- **Data access:** Entity Framework Core  
- **Database:** SQL Server  
- **Architectural patterns:**
  - layered architecture (Domain / Infrastructure / Web)
  - domain entities with no infrastructure dependencies
  - DTOs to separate domain from presentation models
- **UI:** Razor Views + Bootstrap (baseline layout, evolving over time)
- **Version control:** Git + GitHub

---

## High-level solution structure

The solution is organized into multiple projects (illustrative names):

- `VendorAccessGovernance.Core`  
  - Domain entities (`ExternalWorker`, `Vendor`, `AccessRequest`, …)  
  - Domain logic

- `VendorAccessGovernance.Infrastructure`  
  - EF Core `DbContext`  
  - mapping configuration and migrations  
  - data access implementations

- `VendorAccessGovernance.Web`  
  - ASP.NET Core MVC (controllers, views, DTOs)  
  - presentation logic and initial UI flows

This separation follows Microsoft’s guidance for modern ASP.NET Core web applications, keeping **domain**, **infrastructure**, and **presentation** clearly decoupled.

---

## Running the project locally

> Note: adapt connection string and .NET version to your environment.

### Prerequisites

- .NET SDK installed  
- SQL Server (local instance or container)  
- Git

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/<your-username>/<your-repo-name>.git
   cd <your-repo-name>
   ```

2. Configure the connection string in `appsettings.Development.json` or using `dotnet user-secrets`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=VendorAccessGovernance;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. Apply EF Core migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the web application:

   ```bash
   dotnet run --project VendorAccessGovernance.Web
   ```

5. Open your browser at the URL shown in the console (for example `https://localhost:5001`).

---

## Roadmap

Some of the next planned user stories:

- **Request lifecycle**
  - define `AccessRequest` states (New, InReview, Approved, Rejected, Revoked)
  - track who changed what and when

- **Authentication & authorization**
  - integrate ASP.NET Core Identity or an external provider
  - introduce roles (admin, project owner, read‑only, etc.)

- **UI/UX improvements**
  - richer views for filtering and searching access requests  
  - layouts tailored for internal enterprise usage

- **API layer**
  - expose REST endpoints so other systems can create/read `AccessRequest` data

---

## About this project & my learning path

This repository is more than just practice code. It’s how I’m learning to:

- start from a **functional specification**  
- identify **domain entities** and relationships  
- prioritize **user stories** with real business impact  
- implement a clean codebase with **C#, ASP.NET Core, EF Core, and SQL Server**

Any feedback on the architecture, domain model, or design decisions is very welcome.
