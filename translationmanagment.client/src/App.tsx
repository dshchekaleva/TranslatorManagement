import { useEffect, useState } from 'react';
import './App.css';

interface Job {
    id: string;
    originalContent: string;
    translatedContent: string;
    customerName: string;
    status: string;
}

function App() {
    const [jobs, setJobs] = useState<Job[]>();

    useEffect(() => {
        populateJobsData();
    }, []);

    const contents = jobs === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
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
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Translation jobs</h1>
            {contents}
        </div>
    );

    async function populateJobsData() {
        const response = await fetch('api/jobs/GetJobs');
        const data = await response.json();
        setJobs(data);
    }
}

export default App;