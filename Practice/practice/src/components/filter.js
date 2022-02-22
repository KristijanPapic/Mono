import { Container,Row,Form,Input, Label, Button} from "reactstrap";
function Filter(){
    return(
        <Container className="bg-light border">
            <Form>
                <Row className="my-3">
                    <Label for="transmissions">Transmission</Label>
                    <Input type="select" id="transmissions">
                        <option>Auto</option>
                        <option>Manual</option>
                    </Input>
                </Row>
                <Row className="my-3">
                <Label for="body_shapes">Body Shape</Label>
                    <Input type="select" id="body_shapes">
                        <option>Coupe</option>
                        <option>Limuzine</option>
                    </Input> 
                </Row>
                <Row className="my-4">
                    <Button type="button" color="info">Apply Filter</Button>
                </Row>
            </Form>
        </Container>
    );
}
export default Filter