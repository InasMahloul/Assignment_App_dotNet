import { useState } from "react";
import { createTask } from "../api/TaskApi";

export const TaskForm = () => {
  const [title, setTitle] = useState("");
  const [errors, setErrors] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);
  const [successMessage, setSuccessMessage] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Reset messages
    setErrors([]);
    setSuccessMessage("");

    // Validation frontend
    if (!title.trim()) {
      setErrors([{ errorMessage: "The title cannot be empty" }]);
      return;
    }

    try {
      setLoading(true);
      const result = await createTask(title);

      if (result.errors) {
        setErrors(result.errors);
      } else {
        setSuccessMessage(`Task created `);
        setTitle("");
      }
    } catch (error) {
      setErrors([{ errorMessage: "Network error. Please try again later " }]);
    } finally {
      setLoading(false);
    }
  };

  return (
    <form className="task-form" onSubmit={handleSubmit}>
      <label htmlFor="title">Create a Task</label>
      <input
        id="title"
        type="text"
        placeholder="Enter the title..."
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        disabled={loading}
      />
      <button type="submit" disabled={loading || !title.trim()}>
        {loading ? "Creation..." : "Create"}
      </button>

      {errors.length > 0 && (
        <div className="error-messages">
          {errors.map((err, i) => (
            <p key={i} className="error">{err.errorMessage}</p>
          ))}
        </div>
      )}

      {successMessage && <p className="success">{successMessage}</p>}
    </form>
  );
};
