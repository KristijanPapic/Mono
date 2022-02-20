import {useParams} from 'react-router-dom'
import{useState,useEffect} from 'react'
import axios from 'axios';
import{Container,Row} from 'reactstrap'
import Model from './model.js'

function Models(){
    const [manufacturerDetail,setManufacturerDetail] = useState([]);
    const {id} = useParams();

    useEffect(() => {
        const Get = async () => {
            await FetchManufacturerById();
            }
        Get()
    },[])

    const FetchManufacturerById = async () => {
        axios.get('https://localhost:44343/api/Manufacturer/' + id).then((response) => {
            setManufacturerDetail(response.data)
            return response.data
        })
    }
    return (
    <Container>
        <h1>{manufacturerDetail.Name}</h1>
        <h3>Models:</h3>
        {manufacturerDetail.Models == undefined ? (<p>loading</p>) : 
        (manufacturerDetail.Models.map((model) => (
            <Model model = {model}/>
        )))
        }
    </Container>
     

    );
}
export default Models;