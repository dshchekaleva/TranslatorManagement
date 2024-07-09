// src/components/AddJob.tsx
import React, { useState } from 'react';

interface CreateJobRequest {
  originalContent: string;
  customerName: string;
}

interface AddJobProps {
  onJobAdded: () => void;
}

const AddJob: React.FC<AddJobProps> = ({ onJobAdded }) => {
  const [form, setForm] = useState<CreateJobRequest>({ originalContent: '', customerName: '' });
  const [success, setSuccess] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setForm(prevForm => ({ ...prevForm, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setSuccess(false);
    setError(null);
    try {
      const response = await fetch('/api/jobs/CreateJob', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(form),
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const result = await response.json();
      setSuccess(result.success);
      onJobAdded();
    } catch (error) {
      setError('Could not create job');
    }
  };

  return (
    <div>
      <h2>Add Job</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>
            Original Content:
            <input type="text" name="originalContent" value={form.originalContent} onChange={handleChange} />
          </label>
        </div>
        <div>
          <label>
            Customer Name:
            <input type="text" name="customerName" value={form.customerName} onChange={handleChange} />
          </label>
        </div>
        <button type="submit">Add Job</button>
      </form>
      {success && <p>Job created successfully!</p>}
      {error && <p>{error}</p>}
    </div>
  );
};

export default AddJob;
