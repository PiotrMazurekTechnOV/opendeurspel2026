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
//question create
server.post("/question/create", async (req, res) => {
  //try {
      const { locations_id, question } = req.body;

      /*if (!locations_id || !question) {
          return res.status(400).json({ error: "Some fields are required." });
      }*/ //not needed yet?

      const con = await connect(); 
      const query = `INSERT INTO opendeurspel.users (locations_id, question) VALUES 
      (?, ?)`;
      await con.execute(query, [locations_id, question]);

      await con.end(); 
      res.status(201).json({ message: "Question created successfully!" });
  //} catch (error) {
    //res.json(error);
  //}
});

// question update
app.post("/question/update/", async (req, res)=>{
 //try {
    const { id, question} = req.body;
     //if(!id || !question) {
      //return res.status(400).json({error: "All fields are required."});
    //}
    const con = await connect(); 
      const query = `UPDATE opendeurspel.questions SET question = ? WHERE id = ?`;
      await con.execute(query, [id, question]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  //} catch (error) {
    //res.json(error);
  //}
});

//answers

//locations

//scores

