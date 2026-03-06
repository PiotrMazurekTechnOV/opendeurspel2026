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

// GET user via id
//why do we need this?
server.get("/user/get/id/:id", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT id FROM users WHERE id = ?", [req.params.id]);
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "User not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// GET user via code
//why do we need this too?
server.get("/user/get/code/:code", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE code = ?", [req.params.code]);
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "User not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

//should add get user via email

// GET all users
//I see no way we can use it, but alr
server.get("/user/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users");
    await con.end();

    res.json(rows);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST add user 
server.post("/user/add", async (req, res) => {
  try {
    const { nameGuardian, nameChild, email} = req.body;

    if (!email) {
      return res.status(400).json({ error: "email required" });
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

  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST update user on code
server.post("/user/update/:code", async (req, res) => {
  try {
    const { nameGuardian, nameChild, email } = req.body;

    const con = await connect();
    const [result] = await con.execute(
      "UPDATE users SET nameGuardian = ?, nameChild = ?, email = ?, WHERE code = ?",
      [nameGuardian, nameChild, email, code, req.params.code]
    );
    await con.end();

    if (result.affectedRows === 0) return res.status(404).json({ error: "User not found" });
    res.json({ message: "User updated" });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST delete user
server.post("/user/delete/:id", async (req, res) => {
  try {
    const con = await connect();
    const [result] = await con.execute("DELETE FROM users WHERE id = ?", [req.params.id]);
    await con.end();

    if (result.affectedRows === 0) return res.status(404).json({ error: "User not found" });
    res.json({ message: "User deleted" });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

//questions
//question add
server.post("/question/add", async (req, res) => {
  //try {
      const { location_number, text } = req.body;

      /*if (!location_number || !text) {
          return res.status(400).json({ error: "Some fields are required." });
      }*/ //not needed yet?
      const con = await connect(); 
      const query = `INSERT INTO questions (location_number, text) VALUES 
      (?, ?)`;
      await con.execute(query, [location_number, text]);

      await con.end(); 
      res.status(201).json({ message: "Question added successfully!" });
  //} catch (error) {
    //res.json(error);
  //}
});

// question update
server.post("/question/update/:id", async (req, res)=>{
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
server.post("/question/delete/:id", async (req, res)=>{
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
server.get("/question/get/:id", async (req, res, next) => {
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

//Read questions
server.get("/questions/read", async (req, res, next) => {
  try {
    const con = await connect(); 
    const query = "SELECT * FROM questions";
    
    // Execute query properly
    const [rows] = await con.execute(query);
    //console.log(rows)
    con.end(); // Close connection after the query

    /*
    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Location not found." });
    }
    */
    res.status(200).json(rows);

  } catch (error) {
    //console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

//answers
// POST add answer
server.post("/answers/add", async (req, res) => {
  try {
    const answers = req.body; // Expecting an array of { text, question_id, correct }

    if (!Array.isArray(answers) || answers.length === 0) {
      return res.status(400).json({ error: "Answers array is required" });
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
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST update answer
server.post("/answer/update/", async (req, res) => {
  //try {
    const { id, text } = req.body;

    //if (!id || !text ) {
      //return res.status(400).json({ error: "not all fields are filled" });
    //}

    const con = await connect();
    await con.execute(
      "UPDATE answers SET text = ? WHERE id = ?",
      [id,text]
    );
    await con.end();

    //if (result.affectedRows === 0) return res.status(404).json({ error: "Answer not found" });
    res.status(200).json({ message: "Answer updated" });
  //} catch (err) {
    //res.status(500).json({ error: err.message });
  //}
});

// POST delete answer
server.post("/answer/delete/", async (req, res) => {
  try {
    const id = req.body;

    if (!id) {
      return res.status(400).json({ error: "Please provide an answer ID." });
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

    if (rows.length === 0) return res.status(404).json({ error: "Answer not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});
server.get("/answer/get/question-on-id/:questionId", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers WHERE question_id = ?", [req.params.questionId]);
    await con.end();

    res.json(rows);
  } catch (err) {
    res.status(500).json({ error: err.message });
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



//GET correct antwoord via question id
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

    if (!answers || questions_id === undefined) {
      return res.status(400).json({ error: "answers and questions_id are required" });
    }

    const con = await connect();
    await con.execute(
      "INSERT INTO answers (answers, questions_id) VALUES (?, ?)",
      [answers, questions_id]
    );
    await con.end();

    res.status(201).json({ message: "Answer added" });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST update answer
server.post("/answer/update/:id", async (req, res) => {
  try {
    const { answers, questions_id } = req.body;

    if (!answers || questions_id === undefined) {
      return res.status(400).json({ error: "answers and questions_id are required" });
    }

    const con = await connect();
    const [result] = await con.execute(
      "UPDATE answers SET answers = ?, questions_id = ? WHERE id = ?",
      [answers, questions_id, req.params.id]
    );
    await con.end();

    if (result.affectedRows === 0) return res.status(404).json({ error: "Answer not found" });
    res.json({ message: "Answer updated" });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// POST delete answer
server.post("/answer/delete/:id", async (req, res) => {
  try {
    const con = await connect();
    const [result] = await con.execute("DELETE FROM answers WHERE id = ?", [req.params.id]);
    await con.end();

    if (result.affectedRows === 0) return res.status(404).json({ error: "Answer not found" });
    res.json({ message: "Answer deleted" });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

// GET all answers
server.get("/answer/get/all", async (req, res) => {
  try {
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM answers", [req.params.code]);
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "answers not found" });
    res.json(rows);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

//locations
//location add
server.post("/location/add", async (req, res) => {
  try {
      const { number, localName } = req.body;

      if (!number || !name) {
          return res.status(400).json({ error: "All fields are required." });
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
      return res.status(400).json({error: "All fields are required."});
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
      return res.status(400).json({ error: "Please provide a location ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM locations WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Location not found." });
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
    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Location not found." });
    }
    */
    res.status(200).json(rows);

  } catch (error) {
    //console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

//scores
//voorbeeld code (niet met onze database verbonden)
//GET locatios opvragen aan de hand van id

server.get("/question/get/location/:location_number", async (req, res) => {
  try {
    const { location_number } = req.params;
 
    const con = await connect();
    const query = `
      SELECT text FROM questions
      WHERE location_number = ?
    `;
    const [rows] = await con.execute(query, [location_number]);
    await con.end();
 
    res.status(200).json(rows[0]);
 
  } catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});


//DELETE location
server.get("/location/delete/:id", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL

    if (!id) {
      return res.status(400).json({ error: "Please provide an location ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM locations WHERE id = ?"; 
    const [result] = await con.execute(query, [id]); // Voer de delete query uit

    await con.end(); 
    
    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Location not found." });
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

    if (rows.length === 0) return res.status(404).json({ error: "locations not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});


//scores
server.post("/scores/add", async (req, res) => {
  try {
      const { user_id, question_id, correct } = req.body;




      if (!user_id || !question_id ||!correct) {
          return res.status(400).json({ error: "All fields are required." });
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
      return res.status(400).json({error: "All fields are required."});
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
      return res.status(400).json({ error: "Please provide a score ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM scores WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    console.log(rows)
    con.end(); // Close connection after the query

    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: " not found." });
    }

    res.json({ data: rows });

  } catch (error) {
    console.error(error);
  }});

//printer
server.post("/print", async (req,res) => {
  //user opzoeken
  //score bereken
  //pdf genereren
  //pdf afdrukken
})
   //DELETE score
   //er is geen DELETE voor score dus baseer mij op die van location
  server.get("/score/delete/:id", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL

    if (!id) {
      return res.status(400).json({ error: "Please provide an score ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM scores WHERE id = ?"; 
    const [result] = await con.execute(query, [id]); // Voer de delete query uit

    await con.end();
    
    if (result.affectedRows === 0) {
      return res.status(404).json({ error: "Score not found." });
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

    if (rows.length === 0) return res.status(404).json({ error: "scores not found" });
    res.json(rows[0]);
  } catch (err) {
    res.status(500).json({ error: err.message });
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

