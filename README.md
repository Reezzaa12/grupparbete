# Personnummerkontrollapplikation

## Description
This C# console application provides functionality to validate and analyze Personnummer (Swedish personal identification numbers). It includes a user interface for manual input and unit tests for automated validation.

## Table of Contents
- [Features](#features)
- [How to Run Locally](#how-to-run-locally)
- [How to Run Using Docker](#how-to-run-using-docker)
- [Personnummer Rules](#personnummer-rules)
- [How the Application Performs the Check](#how-the-application-performs-the-check)
- [Unit Tests](#unit-tests)
- [Group Members](#group-members)

## Features
- Validates the personnummer.
- Determines the gender based on the personnummer.
- Calculates the age of the person based on what year they are born.
- Unit tests for automated validation.

## How to Run Locally
1. Clone the repository:
```cs
git clone https://github.com/Reezzaa12/grupparbete.git
```

2. Open the project in your preferred code editor.

3. Run the program.

4. Input a Swedish personal number or write ‘exit’ to quit the program.

## How to Run Using Docker
Using Git Bash (Windows) or Terminal(Mac):
1. Ensure Docker is installed on your machine (available at [Docker Installation](https://www.docker.com/get-started/)).

2. Build the Docker image:
   ```
   docker build -t grupparbete .
   ```

3. Run the Docker container:
   ```
   docker run -it grupparbete
   ```

Using Docker Desktop/Docker Hub
1. Search rezkar/grupparbete or go through this [link](https://hub.docker.com/r/rezkar/grupparbete)

2. **Pull** the docker image.

3. **Run** the docker image 

## Personnummer Rules
A personnummer is a unique identifier assigned to individuals. It follows a specific format: ÅÅMMDD-XXXX or ÅÅMMDD+XXXX, where:

- **ÅÅ**: The last two digits of the birth year.
- **MM**: The birth month.
- **DD**: The birth day.
- **XXXX**: A four-digit sequence number, where the first three numbers represent a birth number which distinguishes individuals born on the same day. The third number indicates the gender of that person, an even number indicating a female and an odd number indicating a male The last one is a verification number (sv. kontrollsiffra) which is calculated using the [Luhn Algorithm](https://sv.wikipedia.org/wiki/Luhn-algoritmen/).

The seventh digit can be either a hyphen '-' or a plus sign '+'. The century of birth is determined the rule: 
**-** for a person under the age of 100 years old
**+** for a person over the age of 100 years old.

## How the Application Performs the Check
The application checks the validity of a personnummer using the Luhn algorithm [Luhn Algorithm](https://sv.wikipedia.org/wiki/Luhn-algoritmen/). Here's a breakdown of the validation process:

1. **Input Validation:**
   - The application ensures that the input is 11 characters long and that the seventh character is either a hyphen or a plus sign.

2. **Formatting:**
   - The hyphen is removed from the personnummer, leaving a 10-digit number.

3. **Checksum Calculation:**
   - A sum is calculated based on each digit's position using a specific formula.
   - If a result is greater than 9, 9 is subtracted from it.
   - The sum of these calculations is then checked to see if it is evenly divisible by 10.

4. **Gender Identification:**
   - The gender of the person is determined by examining the ninth digit. An even digit represents "Kvinna" (woman), and an odd digit represents "Man" (man).

5. **Age Calculation:**
   - The birth year is extracted from the personnummer, and the age is calculated based on the current year.
   - Special consideration is given to individuals with a 'plus' sign in the seventh position, indicating they are over 100 years old.

6. **Display Results:**
   - The application outputs whether the personnummer is valid, the gender, the calculated age, and a message indicating if the person is under 100 years old or over 100 years old.

## Unit Tests
The project includes unit tests using xUnit. To run the tests:

1. Open a terminal in the project directory.

2. Run the command:
   ```cs
   dotnet test
   ```

## Group Members
Course: CI/CD

Group 6 consists of:
- Alexander H.
- Eden
- Fadia
- Reza
- Una
