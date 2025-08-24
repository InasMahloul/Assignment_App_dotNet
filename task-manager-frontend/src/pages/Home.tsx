import React from "react";
import { useNavigate } from "react-router-dom";

export const Home = () => {
  const navigate = useNavigate();

  return (
    <div className="home-container">
      <h1>Welcome to the Task Manager</h1>
      <p>Organize your tasks quickly and easily.</p>
      <button onClick={() => navigate("/create-task")} style={{ marginRight: "10px" }}>
          Create a Task
      </button>
      <button onClick={() => navigate("/tasks")}>
          View my tasks
      </button>

    </div>
  );
};

export {}; 
