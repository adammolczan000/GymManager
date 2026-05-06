import { useAuth } from '../context/AuthContext';
import { useNavigate } from 'react-router-dom';

function Dashboard() {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Witaj, {user?.username}!</h2>
      <p>Rola: {user?.role}</p>
      <button onClick={handleLogout}>Wyloguj się</button>
    </div>
  );
}

export default Dashboard;