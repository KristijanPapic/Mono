import { Container,Row,Form,Input, Label, Button,Col} from "reactstrap";
function Filter(){
    const year = (new Date()).getFullYear();
    const years = Array.from(new Array(30),( val, index) => year - index);
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
                <Row className="my-3">
                    <Label for='power'>Enhine power (hp)</Label>
                    <Row className="m-auto">
                        <Col md='5'>
                            <Input type="number" id="power"/>
                        </Col>
                        <Col md='2'>
                        <p>to</p>
                        </Col>
                        <Col md='5'>
                            <Input type="number" id="power"/>
                        </Col>
                    </Row>
                </Row>
                <Row className="my-3">
                    <Label for='year'>Year</Label>
                    <Row className="m-auto">
                        <Col md='5'>
                            <Input type="select" id="year">
                               {years.map((year, index) => {
                                    return <option key={index} value={year}>{year}</option>
                                })}
                            </Input>
                        </Col>
                        <Col md='2'>
                        <p>to</p>
                        </Col>
                        <Col md='5'>
                        <Input type="select" id="year">
                               {years.map((year, index) => {
                                    return <option key={index} value={year}>{year}</option>
                                })}
                            </Input>
                        </Col>
                    </Row>
                </Row>
                <Row className="my-4">
                    <Button type="button" color="info">Apply Filter</Button>
                </Row>
            </Form>
        </Container>
    );
}
export default Filter