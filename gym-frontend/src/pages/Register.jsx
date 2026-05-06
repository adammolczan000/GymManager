import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import api from '../api/axiosConfig';

function Register() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccess('');

    if (password !== confirmPassword) {
      setError('Passwords do not match.');
      return;
    }

    if (password.length < 6) {
      setError('Password must be at least 6 characters long.');
      return;
    }

    try {
      const response = await api.post('/auth/register', { email, password });
      setSuccess('Account created! Redirecting...');
      login(response.data.token, { email, role: response.data.role });
      setTimeout(() => navigate('/'), 1500);
    } catch (err) {
      setError(err.response?.data?.message || 'Registration error. Please try again.');
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Register</h2>
        <p className="auth-subtitle">Create a new account</p>

        {error && <div className="error-message">{error}</div>}
        {success && <div style={{ background: '#efe', color: '#3c3', padding: '12px 16px', borderRadius: '6px', marginBottom: '20px', borderLeft: '4px solid #3c3' }}>{success}</div>}

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input
              id="email"
              type="email"
              placeholder="Enter your email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>

          <div className="form-group">
            <label htmlFor="password">Hasło</label>
            <input
              id="password"
              type="password"
              placeholder="Enter password (minimum 6 characters)"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          <div className="form-group">
            <label htmlFor="confirmPassword">Potwierdź hasło</label>
            <input
              id="confirmPassword"
              type="password"
              placeholder="Enter password again"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              required
            />
          </div>

          <button type="submit" className="auth-button">
            Sign Up
          </button>
        </form>

        <div className="auth-link">
          Already have an account? <a href="/login">Sign in</a>
        </div>
      </div>
    </div>
  );
}

export default Register;