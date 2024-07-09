import React, { useEffect, useState } from 'react';
import AddJob from './AddJob';

interface Job {
    id: string;
    originalContent: string;
    translatedContent: string;
    customerName: string;
    status: string;
}

const JobList: React.FC = () => {
    const [jobs, setJobs] = useState<Job[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [showAddJob, setShowAddJob] = useState<boolean>(false);

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await fetch('/api/jobs/GetJobs');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data: Job[] = await response.json();
                setJobs(data);
            } catch (error) {
                setError('Could not fetch jobs');
            } finally {
                setLoading(false);
            }
        };

        fetchJobs();
    }, []);

    const handleJobAdded = () => {
        setShowAddJob(false);
        //setLoading(true);
        //setError(null);
        //setJobs([]);
        fetchJobs();
    };

    if (loading) return <p>Loading...</p>;
    if (error) return <p>{error}</p>;

    return (
        <div>
            <h2>Jobs</h2>
            {!showAddJob && <button onClick={() => setShowAddJob(true)}>Add Job</button>}
            {showAddJob ? (
                <AddJob onJobAdded={handleJobAdded} />
            ) : (
                <ul>
                    {jobs.map(job => (
                        <li key={job.id}>
                            <p>Original Content: {job.originalContent}</p>
                            <p>Translated Content: {job.translatedContent}</p>
                            <p>Customer: {job.customerName}</p>
                            <p>Status: {job.status}</p>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default JobList;