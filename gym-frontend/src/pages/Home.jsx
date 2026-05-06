import { useState, useEffect } from 'react';
import { useAuth } from '../context/AuthContext';
import { useNavigate } from 'react-router-dom';
import api from '../api/axiosConfig';

function Home() {
  const [classes, setClasses] = useState([]);
  const [loading, setLoading] = useState(true);
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchClasses = async () => {
      try {
        const response = await api.get('/classes');
        setClasses(response.data);
      } catch (err) {
        console.log('Error fetching classes:', err);
      } finally {
        setLoading(false);
      }
    };
    fetchClasses();
  }, []);

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  return (
    <>
      {/* Row 1: Header */}
      <div className="header">
        <h1>GymManager</h1>
        <div className="header-right">
          {user ? (
            <>
              <span>Logged in: {user.email.split('@')[0]}</span>
              <button onClick={handleLogout}>Logout</button>
            </>
          ) : (
            <button onClick={() => navigate('/login')}>Login</button>
          )}
        </div>
      </div>

      {/* Row 2: Schedule Title */}
      <div className="schedule-section">
        <h2>Class Schedule</h2>

        {/* Row 3: Classes */}
        {loading && <p className="loading">Loading...</p>}

        {!loading && classes.length === 0 && (
          <p className="no-classes">No classes available.</p>
        )}

        {!loading && (
          <div className="classes-container">
            {classes.map((cls) => (
              <div key={cls.id} className="class-card">
                <h3>{cls.name}</h3>
                <p>{cls.description}</p>
                <p className="schedule-time">
                  Date: {new Date(cls.scheduledAt).toLocaleString('en-US')}
                </p>
                <p>Capacity: {cls.maxCapacity}</p>
                {user && (
                  <button onClick={() => console.log('Reserve:', cls.id)}>
                    Reserve
                  </button>
                )}
              </div>
            ))}
          </div>
        )}
      </div>
    </>
  );
}

export default Home;
