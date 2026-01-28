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

//endpoints programmeren (correcte URL en correcte SQL queries uitvoeren) + response terugsturen//user

//user

//questions
//question add
server.post("/question/add", async (req, res) => {
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
      res.status(201).json({ message: "Question added successfully!" });
  //} catch (error) {
    //res.json(error);
  //}
});

// question update
server.post("/question/update/", async (req, res)=>{
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
// question delete
server.post("/question/delete/", async (req, res)=>{
    try {
    const id = req.body;

    if (!id) {
      return res.status(400).json({ error: "Please provide a question ID." });
    }

    const con = await connect(); 
    const query = `DELETE FROM questions WHERE id = ?`;
    await con.execute(query, [id]);

    await con.end(); 
      res.status(200).json({ message: "Question deleted" });
    }
    catch (error){ res.status(500).json(error);}
});
// read question on id
app.get("/question/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; // Get the question ID from the URL

    if (!id) {
      return res.status(400).json({ error: "Please provide a question ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM questions WHERE id = ?";
    
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); 

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Question not found." });
    }

    res.json({ message: "Question read successfully!", data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});

//answers

//locations

//scores


// Start server
const PORT = process.env.PORT;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});
server.get("/", (req, res) => {
  res.send("WELKOM!!!");
});