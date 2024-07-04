import './App.css';
import React, { useState } from 'react';

function App() {
  const [inputData, setInputData] = useState('');

  const handleInputChange = (event) => {
    setInputData(event.target.value);
  };

  const sendDataToUnity = async (data) => {
    try {
      const response = await fetch('http://localhost:3001/', { 
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ userType: data })  
      });

      if (response.ok) {
        console.log("Data sent successfully");
      } else {
        console.error("Error sending data");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  const handleSubmit = () => {
    sendDataToUnity(inputData);
  };

  return (
    <div className="App">
      <header className="App-header">
        <label className='App-content'>Please specify user type:</label>
        <input type='text' placeholder='supervisor/normal' className='App-content' onChange={handleInputChange}/>
        <button type='button' onClick={handleSubmit}>Submit</button>
      </header>
    </div>
  );
}

export default App;
