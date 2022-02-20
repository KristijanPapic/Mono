import {useParams} from 'react-router-dom'
import{useState,useEffect} from 'react'
import axios from 'axios';
import{Container,Row} from 'reactstrap'
import Model from './model.js'
import ModelVersion from './modelVersion.js'


function ModelVersions() {

const [modelVersions,setModelVersions] = useState([]);
const {modelId} = useParams();

useEffect(() => {
    const Get = async () => {
        await FetchModelVersions();
        }
    Get()
},[])

const FetchModelVersions = async () => {
    axios.get('https://localhost:44343/api/ModelVersion/',{params: {ModelId : modelId}}).then((response) => {
        console.log(modelId)
        console.log(response.data);
      setModelVersions(response.data)  
})
}

return(
    <Container>
    {modelVersions == null || modelVersions.lenght < 1 ? (<p>loading</p>) : (
        modelVersions.map((modelVersion) => (
        <ModelVersion modelVersion = {modelVersion}/>
    ))) }
</Container>
)
}

export default ModelVersions