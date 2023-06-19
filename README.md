# Invoices Database Management System

This is a repository for the Database Management System project associated with Zewail City University's course on Database Management System. The project aims to develop a system that facilitates the process of managing project invoices for a large-sized, Egypt-based contracting company. The system streamlines the approval cycle of invoices, which involves multiple stages from issuance by the site accountant to final approval by the accounting department.

## System Overview
The project includes the development of a web-based application that serves as an interface between end users and the database management system. This application is designed to streamline the management of project invoices and simplify the approval process. The Entity-Relationship (ER) database model was employed to design and structure the database.

## Main Users
The system caters to the following main users:

1. Company Admin:
   - This user has comprehensive access and modification rights to all data within the system. The privileges of the Company Admin include accessing and approving invoices, assigning permissions to new user accounts, revoking and modifying permissions from user accounts, and suspending any user account.

2. Site Engineer:
   - Site Engineers have the authority to approve, suspend, or deny invoices. They can also suspend an invoice if necessary.

3. Site Accountant:
   - Site Accountants are responsible for creating invoices and forwarding them to individuals with approval authority.

4. Accounting Department:
   - The Accounting Department manages the archiving of invoices.

5. Project Manager:
   - Project Managers can modify the statements of an invoice and have the ability to approve, deny, or suspend invoices.

## Project Phases
The project is divided into three main phases:

### Design Phase:
- ER diagram: Designing the Entity-Relationship diagram to establish the database structure.
- GUI wireframe: Creating a visual representation of the web application's user interface.
- Database schema & scripts: Developing the database schema and necessary scripts.

### Implementation Phase:
- GUI submission: Developing the user interface components and submitting them for review.
- Linking between the UI with the backend and database: Establishing the connection between the user interface, backend logic, and the database.
- Project alpha release: Deploying an alpha release of the project for testing and evaluation.

### Final Delivery Phase:
- This phase involves addressing any identified bugs, enhancing the design based on instructor feedback, and conducting business presentations and technical discussions.
- General bug fixes and design enhancements pointed out by the instructor.
- Business presentation with the Doctor.
- Project technical discussion with the Teaching Assistant.

## Tools & Technologies Used
The project utilizes the following tools and technologies:

- C#: Programming language used for backend development.
- ADO.NET: Data access technology for connecting to the database.
- MySQL Server: Relational database management system.
- Razor Pages: Framework for building web applications.
- Figma: Design tool for creating the GUI wireframes.
- HTML: Markup language for creating web pages.
- CSS: Stylesheet language for styling web pages.
- JavaScript: Programming language for adding interactivity to web pages.

## Getting Started
To get started with the system, follow the steps below:

### Prerequisites
Make sure you have the following prerequisites installed on your system:

- [MySQL Server](https://dev.mysql.com/downloads/)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Installation
1. Clone the repository: `git clone https://github.com/Aya-Sherif/DB-Invoices-System.git`
2. Navigate to the project directory: `cd DB-Invoices-System`
3. Configure the database connection string:
    - Open the `appsettings.json` file.
    - Modify the `DefaultConnection` section with your MySQL Server credentials.
4. Restore the dependencies and build the project.
5. Run the project and view it in your browser's local host
6. The application will be accessible at `http://localhost:5000` in your web browser.



## Contributing

We welcome contributions to enhance the functionality and usability of the system. If you'd like to contribute, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes with descriptive commit messages.
4. Push your changes to your fork.
5. Submit a pull request explaining your changes.


## Contact
If you have any questions, suggestions, or concerns regarding this project, please feel free to contact us:

- Adham Saad: s-adham.saad@zewailcity.edu.eg
- Mohamed Morshedy: s-mohamed.morshedy@zewailcity.edu.eg
- Aya Sherif: s-aya.nassef@zewailcity.edu.eg
- Mahmoud Elshahed: s-mahmoud.elshahed@zewailcity.edu.eg

Thank you for your interest and support!
