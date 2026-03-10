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
    } catch (error) {//...what error does it catch?
        console.error("Error connecting to the database:", error.message);
        throw error;
    }
}

//user
// GET user via id
//why do we need this?
server.get("/user/get/id/:id", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE id = ?", [req.params.id]);
    await con.end();

    if (rows.length == 0) return res.json({error: "User not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(404).json({error});
  }
});

// GET user via code
//why do we need this too?
server.get("/user/get/code/:code", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE code = ?", [req.params.code]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "User not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(404).json({ error });
  }
});

//get user via email
server.get("/user/get/email/:email", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE email = ?", [req.params.email]);
    await con.end();

    if (rows.length == 0) return { error: "User not found"};
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});

server.get("/user/get/email-on-code/:code", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT email FROM users WHERE code = ?", [req.params.code]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "User not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});

// GET all users
//I see no way we can use it, but alr
server.get("/user/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users");
    await con.end();
    if(rows.length == 0) return res.json({error: "users did not return values"})
    res.status(200).json(rows);
  } catch (error) {
    res.status(400).json({ error });
  }
});

// POST add user 
server.post("/user/add", async (req, res) => {
  try {
    const { nameGuardian, nameChild, email} = req.body;

    if (!email) {
      return res.json({ error: "email required" });
    }

    const con = await connect();
    await con.execute(
      "INSERT INTO users (nameGuardian, nameChild, email) VALUES (?, ?, ?)",
      [nameGuardian, nameChild, email]
    );
    //sends the user code back
    const [rows] = await con.execute(`SELECT code FROM users WHERE email = ?`,[email]);
    await con.end();
 
    res.status(200).json(rows[0]);

  } catch (error) {
    res.status(400).json({ error });
  }
});

// POST update user on code
server.post("/user/update/:code", async (req, res) => {
  try {
    //not sure if if nothing written, it sends null or empty string, the later one is fine
    const { nameGuardian, nameChild, email } = req.body;

    const con = await connect();
    const [rows] = await con.execute(
      "UPDATE users SET nameGuardian = ?, nameChild = ?, email = ? WHERE code = ?",
      [nameGuardian, nameChild, email, req.params.code]
    );
    await con.end();

    if (rows.affectedRows == 0) return res.json({ error: "Code doesn't exist" });
    res.status(200).json({ message: "User updated" });
  } catch (error) {
    res.status(404).json({ error });
  }
});

// POST delete user
server.post("/user/delete/", async (req, res) => {
  try {
    //any one of these needs to be given to work
    const {nameGuardian,nameChild,code} = req.body
    const con = await connect();
    const [rows] = await con.execute("DELETE FROM users WHERE nameGuardian = ? OR nameChild = ? OR code = ?",[nameGuardian,nameChild,code]);
    await con.end();

    if (rows.affectedRows == 0) return res.json({ error: "User not found" });
    res.status(200).json({ message: "User deleted" });
  } catch (error) {
    res.status(404).json({ error });
  }
});

//questions
//question add
server.post("/question/add", async (req, res) => {
  try {
    const { location_number, text } = req.body;

    if (!location_number || !text) {
      return res.json({ error: "location_number and text are required." });
    } //not needed yet?
    const con = await connect(); 
    await con.execute(`INSERT INTO questions (location_number, text) VALUES (?, ?)`, [location_number, text]);
    await con.end(); 
    res.status(201).json({ message: "Question added successfully!" });
  } 
  catch (error) 
  {
    res.status(400).json(error);
  }
});

// question update
server.post("/question/update/:location_number", async (req, res)=>{
  try {
    const {text} = req.body;
    if(!text) {
     return res.json({error: "no update text has been given."});
    }
    const con = await connect(); 
    await con.execute(`UPDATE questions SET text = ? WHERE location_number = ?`, [text, req.params.location_number]);
    await con.end(); 
    res.status(200).json({ message: "question updated" });
  } 
  catch (error) 
  {
    res.status(400).json(error);
  }
});

// question delete
server.post("/question/delete/", async (req, res)=>{
  try { 
      const location_number = req.body;
    if (!location_number) {
      return res.json({ error: "Please provide a location number." });
    }
    const con = await connect(); 
    await con.execute(`DELETE FROM questions WHERE location_number = ?`, [location_number]);
    await con.end(); 

    res.status(200).json({ message: "Question deleted" });
  }
  catch (error)
  {
    res.status(400).json(error);
  }
});

// get question on location_number
server.get("/question/get/location/:location_number", async (req,res) => {
  try {
    const con = await connect(); 
    const [rows] = await con.execute("SELECT text FROM questions WHERE location_number = ?", [req.params.location_number]);
    await con.end(); 

    if (rows.length == 0) { 
      return res.json({ error: "Question not found." });
    }
    res.status(200).json(rows[0]);
  } catch (error) 
  {
    res.status(400).json(error);
  }
});

//Get all questions
//why tho?
server.get("/question/get/all/", async (req,res) => {
  try {
    const con = await connect(); 
    const [rows] = await con.execute("SELECT * FROM questions");
    await con.end();

    if (rows.length == 0) {return res.json({ error: "no questions found" });}
    res.status(200).json(rows);
  } catch (error) 
  {
    res.status(400).json(error);
  }
});

//answers
// POST add answer
server.post("/answers/add", async (req, res) => {
  try {
    const {text, correct, question_id} = req.body;
    if(!text || !correct || !question_id){return res.json({error: "text, correct and question_id are requered here"});}
    const con = await connect();
    const [rows] = await con.execute("INSERT INTO answers (text, correct, question_id) VALUES (?, ?, ?)", [text, question_id, correct]);
    await con.end();

    res.status(201).json({ message: "Answers added" }); 
  }
  catch (error) {
    res.status(400).json({ error });
  }
});

// POST update answer
server.post("/answer/update/text", async (req, res) => {
  try {
    const { id, text } = req.body;

    if (!id || !text ) {
      return res.json({ error: "id and text are required" });
    }

    const con = await connect();
    await con.execute("UPDATE answers SET text = ? WHERE id = ?",[text,id]);
    await con.end();

    if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.status(200).json({ message: "Answer updated" });
  } catch (error) {
    res.status(400).json({ error });
  }
});

server.post("/answer/update/correct", async (req, res) => {
  try {
    const { id, correct } = req.body;

    if (!id || !correct ) {
      return res.json({ error: "id and correct are required" });
    }

    const con = await connect();
    await con.execute("UPDATE answers SET correct = ? WHERE id = ?",[correct,id]);
    await con.end();

    if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.status(200).json({ message: "Answer updated" });
  } catch (error) {
    res.status(400).json({ error });
  }
});

// POST delete answer
server.post("/answer/delete/id", async (req, res) => {
  try {
    const {id} = req.body;

    if (!id) {
      return res.json({ error: "Please provide an answer ID." });
    }

    const con = await connect(); 
    await con.execute(`DELETE FROM answers WHERE id = ?`, [id]);
    await con.end(); 

    if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.status(200).json({ message: "Answer deleted" });
  }
  catch (error)
  {
    res.status(400).json(error);
  }
});

server.post("/answer/delete/question_id", async (req, res) => {
  try {
    const {question_id} = req.body;

    if (!question_id) {
      return res.json({ error: "Please provide a question_id." });
    }

    const con = await connect(); 
    await con.execute(`DELETE FROM answers WHERE question_id = ?`, [question_id]);
    await con.end(); 

    if (result.affectedRows == 0) return res.json({ error: "Question not found or no answers for that question" });
    res.status(200).json({ message: "Answer(s) deleted" });
  }
  catch (error)
  {
    res.status(400).json(error);
  }
});

// GET answer via id
//huh??? that's useless here, no way to know id
server.get("/answer/get/id/:id", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT text,correct,question_id FROM answers WHERE id = ?", [req.params.id]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "Answer not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});

//probably not needed
server.get("/answer/get/question-on-id/:question_id", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT text,correct FROM answers WHERE question_id = ?", [req.params.question_id]);
    await con.end();

    res.json(rows);
  } catch (error) {
    res.status(500).json({ error });
  }
});

// GET answers via location number
server.get("/answer/get/question-on-location/:location_number", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT answers.text,correct FROM answers JOIN questions ON answers.question_id = questions.id JOIN locations ON questions.location_number = locations.number", [req.params.location_number]);
    await con.end();

    if(con.length == 0) return res.json({error: "There are no answers on that location"})
    res.json(rows);
  }catch (error) {
    res.status(404).json({ error });
  }
});

//no idea where we will use that
//GET correct antwoord via question_id
server.get("/answer/get/correct/:question_id", async (req, res) => {
  try {
    const { question_id } = req.params;

    const con = await connect();
    const [rows] = await con.execute(`SELECT text FROM answers WHERE question_id = ? AND correct = 1`, [question_id]);
    await con.end();
    if(con.length == 0) return res.json({error: "either no correct answers or no answers"})
    res.status(200).json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});

// GET all answers
//weid that we have it, but sure, why not
server.get("/answer/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers");
    await con.end();

    if (rows.length == 0) return res.json({ error: "no answers found" });
    res.json(rows);
  } catch (error) {
    res.status(404).json({ error });
  }
});

//locations
//location add
server.post("/location/add", async (req, res) => {
  try {
      const { number, localName } = req.body;

      if (!number || !localName) {
        return res.json({ error: "location needs both a number and a location name." });
      }
      const con = await connect(); 
      await con.execute(`INSERT INTO locations (number, localname) VALUES (?, ?)`, [number, localName]);
      await con.end(); 

      res.status(201).json({ message: "Location created successfully!" });
  } catch (error) {
    res.json({ error });
  }
});

//location UPDATES
server.post("/location/update/localName", async (req, res)=>{
  try {
    const { number, localName} = req.body;
    if(!number || !localName) {
      return res.json({error: "A location number and a location name are required."});
    }
    const con = await connect();
    await con.execute(`UPDATE locations SET localName = ? WHERE number = ?`, [localName, number]);
    await con.end(); 

    if(con.affectedRows == 0) return res.json({error: "No such number found"})
    res.status(200).json({ message: "name updated!" });
  } catch (error) {
    res.json({ error });
  }}
);

server.post("/location/update/number", async (req, res)=>{
  try {
    const { number, localName} = req.body;
    if(!number || !localName) {
      return res.json({error: "A location number and a location name are required."});
    }
    const con = await connect();
    await con.execute(`UPDATE locations SET number = ? WHERE localName = ?`, [number, localName]);
    await con.end(); 

    if(con.affectedRows == 0) return res.json({error: "No such name found"})
    res.status(200).json({ message: "number updated!" });
  } catch (error) {
    res.json({ error });
  }}
);

//Read Locations
server.get("/location/get/id/:id", async (req, res) => {
  try {
    const con = await connect(); 
    const [rows] = await con.execute("SELECT number,localName FROM locations WHERE id = ?", [req.params.id]);
    con.end();

    if (rows.length == 0) {return res.json({ error: "Id has not been found." });}
    res.status(200).json(rows[0]);
  } catch (error) 
  {
    res.status(500).json({ error });
  }
});

//get Locations
//at least this all can find it's use somewhere
server.get("/location/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM locations");
    con.end();

    if (rows.length == 0) {return res.json({ error: "No locations availible" });}
    res.status(200).json(rows);
  } catch (error) 
  {
    res.status(404).json({ error });
  }
});

//DELETE location
server.get("/location/delete/number/", async (req, res) => {
  try {
    const { number } = req.body;
    if (!number) {return res.json({ error: "Please provide an location number." });}
    const con = await connect();
    const [result] = await con.execute("DELETE FROM locations WHERE number = ?", [number]);
    await con.end(); 
    
    if (result.affectedRows == 0) {return res.json({ error: "Location not found." });}
    res.status(200).json({ message: "Location deleted successfully!" });
  } catch (error) {
    res.status(400).json({ error });
  }
});

server.get("/location/delete/localName", async (req, res) => {
  try {
    const { localName } = req.body;
    if (!localName) {return res.json({ error: "Please provide an location name." });}
    const con = await connect();
    const [result] = await con.execute("DELETE FROM locations WHERE localName = ?", [localName]);
    await con.end(); 
    
    if (result.affectedRows == 0) {return res.json({ error: "Location not found." });}
    res.status(200).json({ message: "Location deleted successfully!" });
  } catch (error) {
    res.status(400).json({ error });
  }
});

//I wonder when will this be used...
server.get("/location/get/number/:number", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT localName FROM locations WHERE number = ?", [req.params.number]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "location number not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(404).json({ error });
  }
});

//Yo, honestly just remake the whole scores table, user_code instead of id, and status, maybe just give it a better name
//while I'm at it, or maybe just call it correct like it was in other table used
//scores
server.post("/score/add", async (req, res) => {
  try {
      const { user_id, question_id, status } = req.body;
      if (!user_id || !question_id ||!status) {return res.json({ error: "All fields are required." });}

      const con = await connect(); 
      await con.execute(`INSERT INTO scores (user_id, question_id, status) VALUES (?, ?, ?)`, [user_id, question_id, status]);
      await con.end(); 

      res.status(201).json({ message: "Scores created successfully!" });
  } catch (error) 
  {
    res.status(400).json(error);
  }
});

//update score
server.post("/score/update/:user_id", async (req, res)=>{
  try {
    const {status,question_id} = req.body;
    if(!status || !question_id) {return res.json({error: "new status is required and the question ID."});}
    const con = await connect(); 
    await con.execute(`UPDATE scores SET status = ? WHERE user_id = ? AND question_id = ?`, [status,req.params.user_id,question_id]);
    await con.end();

    res.status(200).json({ message: "Data updated!" });
  } 
  catch (error) 
  {
    res.json({ error });
  }
});

//DELETE score
server.post("/score/delete/", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL
    if (!id) {return res.json({ error: "Please provide an score ID." });}
    const con = await connect(); 
    const [rows] = await con.execute("DELETE FROM scores WHERE id = ?", [id]); 
    await con.end();
    
    if (result.affectedRows == 0) {return res.json({ error: "Score not found. Check the id" });}
    res.json({ message: "Score deleted successfully!" });
  } 
  catch (error) 
  {
    res.status(400).json({ error });
  }
});

server.get("/score/get/:user_code", async (req,res) =>{
  try 
  {
    const con = await connect();
    const [rows] = await con.execute("SELECT user_id,question_id,status,nameGuardian,nameChild,email FROM scores JOIN users ON scores.user_id = users.id WHERE users.code = ?",[req.params.user_code])
    await con.end();

    if(rows.length == 0){return res.json({error: "user code not found"})}
    res.status(200).json(rows)
  }
  catch (error)
  {
    res.status(404).json({ error })
  }
});

// GET all scores
server.get("/score/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM scores");
    await con.end();

    if (rows.length == 0) return res.json({ error: "scores not found" });
    res.status(200).json(rows);
  } catch (error) {
    res.status(500).json({ error });
  }
});

//get diploma %
server.get("/diploma/get/:user_id", async (req, res, next) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT ROUND(AVG(status),2) * 100 FROM scores WHERE user_id = ?", [req.params.user_id]);
    con.end();

    if (rows.length == 0) {return res.json({ error: " not found." });}
    res.json(rows[0]);
  } 
  catch (error) 
  {
    res.status(404).json({ error })
  }});

// Start server
const PORT = process.env.PORT;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});

server.get("/", (req, res) => {
  res.send("WELKOM!!!"); 
});