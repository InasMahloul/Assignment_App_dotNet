import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Home } from "./pages/Home";
import { TaskForm } from "./components/FormTask";
import { ListTask } from "./components/ListTask";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/create-task" element={<TaskForm />} />
        <Route path="/tasks" element={<ListTask />} />
      </Routes>
    </Router>
  );
}

export default App;
