# DiceRollerWithAnalytics

This UWP application is designed for tabletop role-playing game enthusiasts, allowing them to quickly roll various dice and track the usage analytics.

# Features
- Roll multiple types of dice: 2-sided, 3-sided, 4-sided, 6-sided, 8-sided, 10-sided, 12-sided, 20-sided and 100-sided.
- Track and display total and individual dice roll results.
- Local SQL database to store and analyze dice roll data.
- Display the number of times each dice has been rolled and their average results resetting.

# Why This Project is Useful
Understanding how users interact with your app through analytics helps you to:

- Identify the most commonly used features.
- Optimize user experience by focusing on popular functionalities.
- Improve app performance and user engagement.

# Installationn
1. Clone the repository:
```sh
git clone https://github.com/Learner062022/SQLTableCreationQueries.git
```
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Build and deploy the application to a local machine or emulator.

# Usage
1. Launch the application.
2. Click on any dice button to roll the dice. The result will be displayed on the screen.
3. The total sum of all rolls and the individual roll results are shown at the top.
4. Click the "Clear" button to reset the results and output analytics to the debug console.

# Debug Console Output
  - **Number of times each dice has been rolled.**
  - **Average of all the rolls for each dice.**

# SQL Schema
The following SQL is used to create and manage the dice roll analytics:
```sql
CREATE TABLE IF NOT EXISTS dice_results (
    ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    dice TINYINT UNSIGNED NOT NULL,
    results TINYINT UNSIGNED NOT NULL
);

INSERT INTO dice_results (dice, results) VALUES
(20, 15),
(8, 7),
(6, 1),
(10, 3),
(20, 7),
(20, 19),
(8, 6),
(4, 2),
(2, 2);

SELECT dice, COUNT(dice) AS times_rolled, AVG(results) AS average_dices
FROM dice_results
GROUP BY dice
ORDER BY dice DESC;
```

# Contributing
1. Fork the repository.
2. Create a new branch:
```sh
git checkout -b feature/your-feature
```
3. Commit your changes:
```sh
git commit -am 'Add some feature'
```
4. Push to the branch:
```sh
git commit -am 'Add some feature'
```
5. Open a Pull Request:
```sh
git push origin feature/your-feature
```
