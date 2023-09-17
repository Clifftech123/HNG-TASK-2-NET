
# CRUD REST API for "Person" Resource

Welcome to the CRUD REST API project for managing a "person" resource. This project allows you to perform basic CRUD (Create, Read, Update, Delete) operations on person data. The API is built with C#, .NET, Docker, and PostgreSQL.

## Technologies Used

- C#
- .NET
- Docker
- PostgreSQL

## Overview

This project aims to create a robust REST API for managing person data. It includes endpoints for creating, reading, updating, and deleting person records. The API is designed to handle dynamic parameters, making it flexible to perform operations based on provided details.

## Features

- Create a new person record.
- Retrieve person details by name.
- Update existing person records by name.
- Delete person records by name.
- Dynamic parameter handling for flexible queries.
- Secure interactions with the database to prevent common vulnerabilities.

## Getting Started

1. Clone this repository to your local machine using `git clone` or download the ZIP file and extract it to a folder.

```bash
  git clone https://github.com/your-username/your-repo.git
```

2. Install Docker and Docker Compose on your machine.

3. Create a `.env` file and configure your environment variables (e.g., database connection details).

4. Run the API using Docker Compose.

```bash
  docker-compose up
```

## API Endpoints and HTTP Methods

### Create a Person

- **Endpoint:** `POST  http://localhost:5000/api/persons`

- **Request Format:**

  ```json
  {
    "name": "Clifford Opoku Isaiah"
  }
  ```

- **Response Format (Success):**

```json
{
  "name": "Clifford Opoku Isaiah",
  "id": 1
}
```

This endpoint creates a new person record in the database. The name attribute is required and must be a string. The API returns the newly created person record in the response body.

- **Response Format (Error):**
  If an invalid input is provided, the API returns an error message in the response body.

```json
{
  "error": "Invalid input data"
}
```

### Retrieve a Person

- **Endpoint:** `GET  http://localhost:5000/api/persons/:id`

- **Request Parameters:**
  - id (integer) - The ID of the person record to retrieve.

- **Response Format (Success):**

```json
{
  "name": "Clifford Opoku Isaiah",
  "id": 1
}
```

- **Response Format (Error - Person not found):**

  ```json
  {
    "error": "Person not found"
  }
  ```

### Update a Person

- **Endpoint:** `PUT   http://localhost:5000/api/persons/:id`

- **Request Format:**

  ```json
  {
    "name": "Updated Name"
  }
  ```

- ## Request Parameters

  - id (integer) The ID of the person record to update.
- **Response Format (Success):**

```json
{
  "name": "Updated Name",
  "id": 1
}
```

- **Response Format (Error - Person not found):**

  ```json
  {
    "error": "Person not found"
  }
  ```

### Delete a Person

- **Endpoint:** `DELETE   http://localhost:5000/api/persons/:id`

- **Response Format (Success):** No content (204)

- ## Request Parameters

  - id (integer) The ID of the person record to delete.
- **Response Format (Error - Person not found):**

```json
{
  "error": "Person not found"
}
```


### POSTMAN API AUTOMATION TESTING

This project includes automated tests for each API endpoint using Postman. The tests are located in the `Postman` folder and are organized by endpoint. The tests are designed to run against a local instance of the API. To run the tests, follow the steps below.

## API Points

- **Endpoint:** `POST  http://localhost:5000/api/persons`

- Test code

```js
 - *  `Postman Collection name `: Post-Person-Test

pm.test("Create a Person - Status Code is 201", function () {
    pm.response.to.have.status(201);
});

pm.test("Create a Person - Response  Name", function () {
    pm.response.to.have.jsonBody("name");
});
```

- **Endpoint:** `GET  http://localhost:5000/api/persons/:id`

- Test code

```js
 - *  `Postman Collection name `: Get-Person-by-id
pm.test("Response body is valid JSON", function () {
    pm.response.to.be.json;
});

```

- **Endpoint:** `PUT  http://localhost:5000/api/persons/:id`

- Test code

```js
 - *  `Postman Collection name `: update-person-by-id

pm.test("Update a Person - Status Code is 200", function () {
    pm.response.to.have.status(200);
});

```

- **Endpoint:** `DELETE  http://localhost:5000/api/persons/:id`

- Test code

```js
 - *  `Postman Collection name `: Delete-Person-by-id

pm.test("Update a Person - Status Code is 404", function () {
    pm.response.to.have.status(404);
});

```
