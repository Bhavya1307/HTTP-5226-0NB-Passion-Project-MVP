# HTTP-5226-0NB-Passion-Project-MVP

# Fitness Management System - PlanFitHub.com

## Overview
The Fitness Management System is a web application designed to help users manage their workout plans and exercises. The system allows users to create, edit, and delete workout plans, search for exercises, and associate exercises with workout plans.

## Features
- **Workout Plan Management**: Create, edit, and delete workout plans.
- **Exercise Management**: List, search, and view details of exercises.
- **Associating Exercises with Workout Plans**: Add exercises to specific workout plans, edit and delete them.

## Technologies Used
- **ASP.NET MVC**: For building the web application.
- **Entity Framework**: For database operations.
- **SQL Server**: For storing workout plans and exercises.
- **HTML/CSS**: For front-end design.
- **JavaScript**: For client-side scripting.

## Installation

### Prerequisites
- Visual Studio
- SQL Server

## Usage

### Home Page
The home page provides links to various sections of the application.

### Workout Plans
- **List Workout Plans**: View all workout plans.
- **Create Workout Plan**: Create a new workout plan.
- **Edit Workout Plan**: Edit an existing workout plan.
- **Delete Workout Plan**: Delete a workout plan.

### Exercises
- **List Exercises**: View all exercises.
- **Search Exercises**: Search for exercises by name.
- **View Exercise Details**: View details of a specific exercise.

### Associating Exercises with Workout Plans
- **Add Exercise to Workout Plan**: Select an exercise and add it to a workout plan.

## API Endpoints

### List Exercises
- **URL**: `/api/ExerciseData/ListExercises`
- **Method**: `GET`
- **Response**: Returns a list of exercises.

### Search Exercises
- **URL**: `/api/ExerciseData/SearchExercises?searchString={searchString}`
- **Method**: `GET`
- **Response**: Returns a list of exercises matching the search string.

### Find Exercise by ID
- **URL**: `/api/ExerciseData/FindExercise/{id}`
- **Method**: `GET`
- **Response**: Returns the details of the specified exercise.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue to discuss potential changes.

## Contact
For any questions or feedback, please contact [bdp9834@gmail.com](mailto:bdp9834@gmail.com).

### Steps to run the project
1. **Clone the repository**:
    ```bash
    git clone [https://github.com/yourusername/fitness-management.git](https://github.com/Bhavya1307/HTTP-5226-0NB-Passion-Project-MVP.git)
    cd fitness-management
    ```

2. **Open the project**:
    Open the solution file `Fitness_Management.sln` in Visual Studio.

3. **Restore NuGet packages**:
    In Visual Studio, go to `Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution` and restore the required packages.

4. **Update the database connection string**:
    Update the connection string in `Web.config` to point to your SQL Server instance.

5. **Run the migrations**:
    In Visual Studio, open the Package Manager Console and run:
    ```bash
    Update-Database
    ```

6. **Run the application**:
    Press `F5` to build and run the application.
