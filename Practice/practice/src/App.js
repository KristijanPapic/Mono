import logo from './logo.svg';
import './App.css';
import Navbar from './components/navbar.js'
import Manufacturers from './components/manufacturers.js';
import Models from './components/models.js'
import ModelVersions from './components/modelVersions';
import axios from 'axios';
import{useState,useEffect} from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'





function App() {

  const [manufacturers,setManufacturers]= useState([])

  useEffect(() => {
    const getManufacturers = async () => {
      await fetchManufacturers();
    }
    getManufacturers()
  }, [])
  
  
  const fetchManufacturers = async () => {
    axios.get('https://localhost:44343/api/Manufacturer').then((response) => {
      console.log(response.data);
        setManufacturers(response.data);
        return response.data;
      })
    };
  return (
    <Router>
      <div className="App">
        <Navbar/>
          <Routes>
            <Route
            path='/'
            element={
              <Manufacturers manufacturers={manufacturers}/>
            }
            />
            <Route
            path='/Manufacturer/:id'
            element={
              <Models/>
            }
            />
            <Route
            path='/Model/:modelId'
            element={
              <ModelVersions/>
            }
            />
            </Routes>
      
      </div>
    </Router>
    
  );
}

export default App;
