# FlightsManagerDOTNet

## ✈️ About
Are you an airport customer service manager or part of an operations team? Do you handle day-to-day tasks like flight management, assisting travelers, or troubleshooting issues with flight ticket reservations? This Airport Customer Service app is designed to streamline those tasks!

With FlightsManagerDOTNet, you can easily manage flights, assign tickets, and offer efficient service to passengers. As development progresses, employees will gain access to more tools that help streamline their work and improve customer experience.

## 🚀 Technologies Used
- **C#**: Backend logic and data management
- **ASP.NET MVC**: Web application framework for structuring the app
- **Entity Framework Core**: ORM for database interaction
- **SQLite**: Lightweight database used during development
- **Razor**: View engine for generating the user interface

## ✍️ Current Features
- **Flights CRUD Operations**: Create, Read, Update, and Delete flights to manage schedules.
- **Ticket Creation**: Assign tickets to flights, manage seat allocation, and set prices.
- **Flight & Ticket Seeding**: Populate the database with example flights and tickets for demonstration.

## 💻 Installation & Setup
1. Clone the repository: `git clone https://github.com/yourusername/flights-manager-dotnet.git`
2. Navigate to the project directory: `cd flights-manager-dotnet`
3. Install dependencies and set up the database:
    ```bash
    dotnet restore
    dotnet ef database update
    ```
4. Run the project: `dotnet run`
5. Access the app in your browser at `http://localhost:5000`

## 🔧 Basic Improvements
- Enhanced UI for managing multiple flight schedules at once.
- Improved filtering and sorting options for flights and tickets by airline, destination, and departure time.

## 🚀 Future Features
- **JWT Authentication**: Secure login for employees, allowing only authorized users to manage flight and ticket data.
- **Full Ticket Management**: Full CRUD operations for tickets, including creation, updates, and deletion, with sorting and filtering options based on flight details.
- **Employee Dashboard**: A personalized view showing flight assignments, upcoming flights, and pending issues, with tools to manage customer service interactions, such as rebooking and seat availability checks.
- **Many-to-Many Relationship for Meals**: Track and assign meal options for flights, offering customizable preferences for passengers.
- **Real-Time Flight Data**: Fetch live flight statuses from third-party APIs for accurate flight information.

## 🧊🥊 Ice Box Features
- **Customer Rebooking**: Allow employees to rebook passengers quickly in case of delays or cancellations.
- **Customer Feedback & Notifications**: Collect passenger feedback and display real-time notifications for flight changes or updates.
- **Advanced Reporting**: Generate detailed reports on flights, ticket sales, and customer service performance.

## 🤝 Credits
- Microsoft ASP.NET MVC Documentation
- Entity Framework - For simplifying database access
- SQLite/SQL Server - Ensuring seamless data management
- David Stovell's "Add Child Records To Parent" YouTube Tutorial

## 📝 Notes
This app is designed with flexibility in mind, and its functionality can be extended. Updates are planned to streamline workflows for airport employees, and user feedback is welcome!

Screenshots or mockups will be included in future updates to provide a better understanding of the UI.

License information and contributing guidelines will be added as development continues.



