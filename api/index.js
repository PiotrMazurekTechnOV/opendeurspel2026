//packages importeren // done
//db connectie object aanmaken
const express = require("express");
const server = express();
const mysql = require("mysql2/promise");
const bodyParser = require("body-parser");
require('dotenv').config()

server.use(express.json());
server.use(bodyParser.json());

// Database connection 
async function connect() {
    try {
        return await mysql.createConnection({
            host: process.env.HOST,
            user: process.env.USER,
            password: process.env.PASSWORD,
            database: process.env.DB,
        });
    } catch (error) {
        console.error("Error connecting to the database:", error.message);
        throw error;
    }
}

// Start server
const PORT = process.env.PORT;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});
app.get("/", (req, res) => {
  res.send("WELKOM!!!");
});

//endpoints programmeren (correcte URL en correcte SQL queries uitvoeren) + response terugsturen//user

//user

//questions

//answers

//locations

//scores

