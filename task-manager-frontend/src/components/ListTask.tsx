import React, { useEffect, useState } from "react";
import axios from "axios";


const API_URL = "http://localhost:5225/api/Tasks";

export const ListTask = () => {
  const [tasks, setTasks] = useState<{ id: string; title: string }[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const response = await axios.get(API_URL);
        setTasks(response.data);
      } catch (err: any) {
        setError("Unable to fetch tasks");
      } finally {
        setLoading(false);
      }
    };

    fetchTasks();
  }, []);

  if (loading) return <p className="info">Loading tasks...</p>;
  if (error) return <p className="error">{error}</p>;

  return (
    <div className="task-list-container">
      <h2>My Tasks</h2>
      {tasks.length === 0 ? (
        <p className="info">No tasks available.</p>
      ) : (
        <ul className="task-list">
          {tasks.map((task) => (
            <li key={task.id} className="task-item">
              {task.title}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};
