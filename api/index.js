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
    con.end(); 

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
    con.end();

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
    const answers = req.body; // Expecting an array of { text, question_id, correct }

    if (!Array.isArray(answers) || answers.length == 0) {
      return resjson({ error: "Answers array is required" });
    }

    const con = await connect();

    // Use a transaction for multiple inserts
    await con.beginTransaction();

    for (const ans of answers) {
      const { text, question_id, correct } = ans;
      await con.execute(
        "INSERT INTO answers (text, question_id, correct) VALUES (?, ?, ?)",
        [text, question_id, correct]
      );
    }

    await con.commit();
    await con.end();

    res.status(201).json({ message: "Answers added", count: answers.length });
  } catch (error) {
    res.status(500).json({ error });
  }
});

// POST update answer
server.post("/answer/update/", async (req, res) => {
  //try {
    const { id, text } = req.body;

    //if (!id || !text ) {
      //return res.json({ error: "not all fields are filled" });
    //}

    const con = await connect();
    await con.execute(
      "UPDATE answers SET text = ? WHERE id = ?",
      [id,text]
    );
    await con.end();

    //if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.status(200).json({ message: "Answer updated" });
  //} catch (error) {
    //res.status(500).json({ error });
  //}
});

// POST delete answer
server.post("/answer/delete/", async (req, res) => {
  try {
    const id = req.body;

    if (!id) {
      return res.json({ error: "Please provide an answer ID." });
    }

    const con = await connect(); 
    const query = `DELETE FROM answers WHERE id = ?`;
    await con.execute(query, [id]);
    await con.end(); 

      res.status(200).json({ message: "Answer deleted" });
    }
  catch (error){ res.status(500).json(error);}
});
 

// GET answer via id
server.get("/answer/get/id/:id", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers WHERE id = ?", [req.params.id]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "Answer not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});
server.get("/answer/get/question-on-id/:questionId", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers WHERE question_id = ?", [req.params.questionId]);
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
    const [rows] = await con.execute("SELECT * FROM answers JOIN questions ON answers.question_id = questions.id JOIN locations ON questions.location_number = locations.number", [req.params.location_number]);
    await con.end();

    res.json(rows[0]);
  }catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});



//GET correct antwoord via question_id
server.get("/answer/get/correct/:question_id", async (req, res) => {
  try {
    const { question_id } = req.params;

    const con = await connect();
    const query = `
      SELECT * FROM answers 
      WHERE question_id = ? AND isCorrect = 1
    `;
    const [rows] = await con.execute(query, [question_id]);
    await con.end();

    res.status(200).json({
      message: "Correct answer retrieved!",
      data: rows
    });

  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

// POST add answer
server.post("/answer/add", async (req, res) => {
  try {
    const { answers, questions_id } = req.body;

    if (!answers || questions_id == undefined) {
      return res.json({ error: "answers and questions_id are required" });
    }

    const con = await connect();
    await con.execute(
      "INSERT INTO answers (answers, questions_id) VALUES (?, ?)",
      [answers, questions_id]
    );
    await con.end();

    res.status(201).json({ message: "Answer added" });
  } catch (error) {
    res.status(500).json({ error });
  }
});

// POST update answer
server.post("/answer/update/:id", async (req, res) => {
  try {
    const { answers, questions_id } = req.body;

    if (!answers || questions_id == undefined) {
      return res.json({ error: "answers and questions_id are required" });
    }

    const con = await connect();
    const [result] = await con.execute(
      "UPDATE answers SET answers = ?, questions_id = ? WHERE id = ?",
      [answers, questions_id, req.params.id]
    );
    await con.end();

    if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.json({ message: "Answer updated" });
  } catch (error) {
    res.status(500).json({ error });
  }
});

// POST delete answer
server.post("/answer/delete/:id", async (req, res) => {
  try {
    const con = await connect();
    const [result] = await con.execute("DELETE FROM answers WHERE id = ?", [req.params.id]);
    await con.end();

    if (result.affectedRows == 0) return res.json({ error: "Answer not found" });
    res.json({ message: "Answer deleted" });
  } catch (error) {
    res.status(500).json({ error });
  }
});

// GET all answers
server.get("/answer/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers", [req.params.code]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "answers not found" });
    res.json(rows);
  } catch (error) {
    res.status(500).json({ error });
  }
});

//locations
//location add
server.post("/location/add", async (req, res) => {
  try {
      const { number, localName } = req.body;

      if (!number || !name) {
          return res.json({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (number, name) VALUES 
      (?, ?)`;
      await con.execute(query, [number, name]);

      await con.end(); 
      res.status(201).json({ message: "Location created successfully!" });
  } catch (error) {
    res.json(error);
  }
});

//UPDATES
server.post("/location/update/:nuber", async (req, res)=>{
  try {
    const { number, name} = req.body;
    if(!number || !name) {
      return res.json({error: "All fields are required."});
    }
    const con = await connect(); 
      const query = `UPDATE locations SET name = ? WHERE number = ?`;
      await con.execute(query, [name, number]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(error);
  }}
);

//Read Locations
server.get("/locations/get/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.json({ error: "Please provide a location ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM locations WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length == 0) { // Checking if the result set is empty
      return res.json({ error: "Location not found." });
    }

    res.json({ data: rows });

  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

//Read Locations
server.get("/locations/read", async (req, res, next) => {
  try {
    const con = await connect(); 
    const query = "SELECT * FROM locations";
    
    // Execute query properly
    const [rows] = await con.execute(query);
    //console.log(rows)
    con.end(); // Close connection after the query

    /*
    if (rows.length == 0) { // Checking if the result set is empty
      return res.json({ error: "Location not found." });
    }
    */
    res.status(200).json(rows);

  } catch (error) {
    //console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

//scores
//DELETE location
server.get("/location/delete/:id", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL

    if (!id) {
      return res.json({ error: "Please provide an location ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM locations WHERE id = ?"; 
    const [result] = await con.execute(query, [id]); // Voer de delete query uit

    await con.end(); 
    
    if (result.affectedRows == 0) {
      return res.json({ error: "Location not found." });
    }

    res.json({ message: "Location deleted successfully!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

// GET all locations
server.get("/location/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM locations");
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "locations not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

server.get("/location/get/number/:code", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM locations WHERE number = ?", [req.params.code]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "locations not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});


//scores
server.post("/scores/add", async (req, res) => {
  try {
      const { user_id, question_id, correct } = req.body;




      if (!user_id || !question_id ||!correct) {
          return resjson({ error: "All fields are required." });
      }

      const con = await connect(); 
      const query = `INSERT INTO users (user_id, question_id, correct) VALUES 
      (?, ?, ?)`;
      await con.execute(query, [user_id, question_id, correct]);

      await con.end(); 
      res.status(201).json({ message: "Scores created successfully!" });
  } catch (error) {
    res.json(error);
  }})

  //update score
  server.post("/score/update/:location_number", async (req, res)=>{
  try {
    const { user_id, question_id, correct} = req.body;
    if(!user_id || !question_id || !correct) {
      return resjson({error: "All fields are required."});
    }
    const con = await connect(); 
      const query = `UPDATE scores SET user_id = ?, correct = ?, WHERE location_number = ?`;
      await con.execute(query, [location_number, text]);

      await con.end();
      res.status(200).json({ message: "Data updated!" });
  } catch (error) {
    res.json(error);
  }})


    //Read scores
  server.get("/scores/get/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return resjson({ error: "Please provide a score ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM scores WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length == 0) { // Checking if the result set is empty
      return res.json({ error: " not found." });
    }

    res.json({ data: rows });

  } catch (error) {
    console.error(error);
  }});

   //DELETE score
   //er is geen DELETE voor score dus baseer mij op die van location
  server.get("/score/delete/:id", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL

    if (!id) {
      return resjson({ error: "Please provide an score ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM scores WHERE id = ?"; 
    const [result] = await con.execute(query, [id]); // Voer de delete query uit

    await con.end();
    
    if (result.affectedRows == 0) {
      return res.json({ error: "Score not found." });
    }

    res.json({ message: "Score deleted successfully!" });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});

// GET all scores
server.get("/score/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM scores", [req.params.code]);
    await con.end();

    if (rows.length == 0) return res.json({ error: "scores not found" });
    res.json(rows[0]);
  } catch (error) {
    res.status(500).json({ error });
  }
});

// Start server
const PORT = process.env.PORT;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});

server.get("/", (req, res) => {
  res.send("WELKOM!!!"); 
});