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

//endpoints programmeren (correcte URL en correcte SQL queries uitvoeren) + response terugsturen

//user
// GET user via id
server.get("/user/get/id/:id", async (req, res) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a user ID." });
    }

    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE id = ?", [req.params.id]);
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "User not found" });
    res.json({ message: "User read successfully!", data: rows });
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});

// GET user via code
server.get("/user/get/code/:code", async (req, res) => {
  try {
    const { code } = req.params; 

    if (!code) {
      return res.status(400).json({ error: "Please provide a user code." });
    }
    const con = await connect();
    const [rows] = await con.execute("SELECT * FROM users WHERE code = ?", [req.params.code]);
    await con.end();

    if (rows.length === 0) return res.status(404).json({ error: "User not found" });
   
    res.json({ message: "User read successfully!", data: rows });
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});

// POST add user
server.post("/user/add", async (req, res) => {
  //try {
    const { nameGuardian, nameChild, email, code } = req.body;

    /*if (!nameGuardian || !nameChild || !email || code === undefined) {
      return res.status(400).json({ error: "nameGuardian, nameChild, email, code are required" });
    }*/ // I assume not needed

    const con = await connect();
    await con.execute(
      "INSERT INTO users (nameGuardian, nameChild, email, code) VALUES (?, ?, ?, ?)",
      [nameGuardian, nameChild, email, code]
    );
    await con.end();

    res.status(201).json({ message: "User added" });
  //} catch (err) {
    //res.status(500).json({ error: err.message });
  //}
});

// POST update user
server.post("/user/update/:id", async (req, res) => {
  //try {
    const { nameGuardian, nameChild, email, code } = req.body;

    const con = await connect();
    const [result] = await con.execute(
      "UPDATE users SET nameGuardian = ?, nameChild = ?, email = ?, code = ? WHERE id = ?",
      [nameGuardian, nameChild, email, code, req.params.id]
    );
    await con.end();

    //if (result.affectedRows === 0) return res.status(404).json({ error: "User not found" });
    res.json({ message: "User updated" });
  //} catch (err) {
    //res.status(500).json({ error: err.message });
  //}
});

// POST delete user
server.post("/user/delete/", async (req, res) => {
    try {
    const id = req.body;

    if (!id) {
      return res.status(400).json({ error: "Please provide a user ID." });
    }

    const con = await connect(); 
    const query = `DELETE FROM users WHERE id = ?`;
    await con.execute(query, [id]);

    await con.end(); 
      res.status(200).json({ message: "User deleted" });
    }
    catch (error){ res.status(500).json(error);}
});

//questions
//question add
server.post("/question/add", async (req, res) => {
  //try {
      const { location_id, text } = req.body;

      /*if (!location_id || !text) {
          return res.status(400).json({ error: "Some fields are required." });
      }*/ //not needed yet?

      const con = await connect(); 
      const query = `INSERT INTO opendeurspel.users (location_id, text) VALUES 
      (?, ?)`;
      await con.execute(query, [location_id, text]);

      await con.end(); 
      res.status(201).json({ message: "Question added successfully!" });
  //} catch (error) {
    //res.json(error);
  //}
});

// question update
server.post("/question/update/", async (req, res)=>{
 //try {
    const { id, text} = req.body;
     //if(!id || !text) {
      //return res.status(400).json({error: "All fields are required."});
    //}
    const con = await connect(); 
      const query = `UPDATE opendeurspel.questions SET text = ? WHERE id = ?`;
      await con.execute(query, [id, text]);

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
    catch (error){ res.status(500).json({error: "Something went terribly wrong"});}
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
    con.end(); 

    res.status(200).json({ message: "Question read successfully!", data: rows });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});

//answers
// POST add answer
server.post("/answer/add", async (req, res) => {
  //try {
    const { text, question_id } = req.body;
    //if (!text || question_id === undefined) {
      //return res.status(400).json({ error: "answer and question_id are required" });
    //}

    const con = await connect();
    await con.execute(
      "INSERT INTO answers (text, question_id) VALUES (?, ?)",
      [text, question_id]
    );
    await con.end();
    res.status(201).json({ message: "Answer added" });
  //} catch (err) {
    //res.status(500).json({ error: err.message });
  //}
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
    const { id } = req.params; // Get the answer ID

    if (!id) {
      return res.status(400).json({ error: "Please provide a answer ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM answers WHERE id = ?";
    const [rows] = await con.execute(query, [id]);
    con.end(); 

    res.json({ message: "Answer read successfully!", data: rows });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});


// GET answers via questionId
server.get("/answer/get/question/:question_id", async (req, res) => {//`_` should be allowed to be used in URLs  
  try {
    const { question_id } = req.params; // Get the answer ID

    if (!question_id) {
      return res.status(400).json({ error: "Please provide a question ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM answers WHERE question_id = ?";
    const [rows] = await con.execute(query, [question_id]);
    con.end(); 

    res.json({ message: "Answer read successfully!", data: rows });
  } catch (error) {
    res.status(500).json({ error: "Something went wrong with the server." });
  }
});

//locations
//location add
server.post("/locations/add", async (req, res) => {
  //try {
      const { number, localName } = req.body;

      /*if (!number || !localName) {
          return res.status(400).json({ error: "All fields are required." });
      }*/

      const con = await connect(); 
      const query = `INSERT INTO locations (number, localName) VALUES 
      (?, ?)`;
      await con.execute(query, [number, localName]);
      await con.end(); 
      res.status(201).json({ message: "Location created successfully!" });
  //} catch (error) {
    ///res.json(error);
  //}
});

//location UPDATE
server.post("/location/update", async (req, res)=>{
  //try {
    const { number, localName} = req.body;
    /*if(!number || !localName) {
      return res.status(400).json({error: "Some fields are required."});
    }*/
    const con = await connect(); 
      const query = `UPDATE locations SET localName = ? WHERE number = ?`;
      await con.execute(query, [localName, number]);

      await con.end(); 
      res.status(200).json({ message: "Success!" });
  //} catch (error) {
    //res.json(error);
  //}
});

//DELETE location
server.post("/location/delete/", async (req, res) => {
  try {
    const { id } = req.params; // Haal het answer ID uit de URL

    if (!id) {
      return res.status(400).json({ error: "Please provide a location ID." });
    }

    const con = await connect(); 
    const query = "DELETE FROM location WHERE id = ?"; 
    await con.execute(query, [id]); // Voer de delete query uit
    await con.end(); 

    res.status(200).json({ message: "Location deleted successfully!" });
  } 
  catch (error) {
    res.status(500).json({ error: "Something went wrong." });
  }
});
//Read Locations
server.get("/locations/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a location ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM locations WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    //console.log(rows)
    con.end(); // Close connection after the query

    /*
    if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: "Location not found." });
    }
    */
    res.status(200).json({message: "Data read successfully!", data: rows});

  } catch (error) {
    //console.error(error);
    res.status(500).json({ error: "Something went wrong." });
  }
});

//scores
//voorbeeld code (niet met onze database verbonden)
//^ nu wel
server.post("/scores/add", async (req, res) => {
  //try {
      const { user_id, question_id, status } = req.body;

      /*if (!user_id || !question_id ||!status) {
          return res.status(400).json({ error: "All fields are required." });
      }*/

      const con = await connect(); 
      const query = `INSERT INTO users (user_id, question_id, status) VALUES 
      (?, ?, ?)`;
      await con.execute(query, [user_id, question_id, status]);

      await con.end(); 
      res.status(201).json({ message: "Score added successfully!" });
  //} catch (error) {
    //res.json(error);
  //}
  })

  //update score
  server.post("/score/update/", async (req, res)=>{
  //try {
    const { question_id, status} = req.body;
    /*if(!user_id || !question_id || !status) {
      return res.status(400).json({error: "All fields are required."});
    }*/
    const con = await connect(); 
      const query = `UPDATE scores SET status = ?, WHERE question_id = ?`;
      await con.execute(query, [status, question_id]);

      await con.end(); 
      res.status(200).json({ message: "Data updated!" });
  //} catch (error) {
    //res.json(error);
  //}
  })

   //score delete
   //er is geen DELETE voor score dus baseer mij op die van location
   //^ beter was om op die van question te baseren
  server.post("/score/delete/", async (req, res) => {
    try {
      const id = req.body;

      if (!id) {
        return res.status(400).json({ error: "Please provide a score ID." });
      }

      const con = await connect(); 
      const query = `DELETE FROM scores WHERE id = ?`;
      await con.execute(query, [id]);
      await con.end(); 

      res.status(200).json({ message: "Score deleted" });
    }
    catch (error){ res.status(500).json({error: "But it refused"});}//heh
});

    //Read scores
  server.get("/scores/read/:id", async (req, res, next) => {
  try {
    const { id } = req.params; 

    if (!id) {
      return res.status(400).json({ error: "Please provide a score ID." });
    }

    const con = await connect(); 
    const query = "SELECT * FROM scores WHERE id = ?";
    
    // Execute query properly
    const [rows] = await con.execute(query, [id]);
    //console.log(rows)
    con.end(); // Close connection after the query
    
    /*if (rows.length === 0) { // Checking if the result set is empty
      return res.status(404).json({ error: " not found." });
    }*/

    res.status(200).json({ message: "Score read successfully!", data: rows });

  } catch (error) {
    res.status(500).json({error: "Something went wrong..."});
    //console.error(error);
  }});

//printer
server.post("/print", async (req,res) => {
  //user opzoeken
const { user_id } = req.body;
  const con = await connect();
  const [userRows] = await con.execute(
    "SELECT * FROM users WHERE id = ?",
    [user_id]
  );
  const user = userRows[0];
  //score bereken
const [scoreRows] = await con.execute(
    "SELECT * FROM scores WHERE user_id = ?",
    [user_id]
  );
  //pdf genereren

  //pdf afdrukken
})

// Start server
const PORT = process.env.PORT;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}.`);
});
server.get("/", (req, res) => {
  res.send("WELKOM!!!"); 
});

