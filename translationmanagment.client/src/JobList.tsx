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
                    <table className="table table-striped" aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Original Content</th>
                                <th>Translated Content</th>
                                <th>Customer</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            {jobs.map(job =>
                                <tr key={job.id}>
                                    <td>{job.id}</td>
                                    <td>{job.originalContent}</td>
                                    <td>{job.translatedContent}</td>
                                    <td>{job.customerName}</td>
                                    <td>{job.status}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
            )}
        </div>
    );
};

export default JobList;