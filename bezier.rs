#[derive(Copy, Clone)]
struct Point 
{
    x : f32,
    y : f32,
}

//Standard linear interpolation
fn lerp(min : f32, max : f32, t : f32) -> f32
{
    return min + (max - min) * t;
}

//Gets a point between two points with bilinear interpolation
fn line_lerp(p1 : Point, p2 : Point, t : f32) -> Point
{
    let x : f32 = lerp(p1.x, p2.x, t);
    let y : f32 = lerp(p1.y, p2.y, t);

    return Point 
    {
        x,
        y,
    };
}

//Interpolates a quadratic bezier curve with three control points, with the interpolant t.
fn quadratic_bezier(p1 : Point, p2 : Point, p3 : Point, t : f32) -> Point 
{
    let a : Point = line_lerp(p1, p2, t);
    let b : Point = line_lerp(p2, p3, t);

    return line_lerp(a, b, t);
}

//Interpolates a cubic bezier curve with three control points, with the interpolant t.
fn cubic_bezier(p1 : Point, p2 : Point, p3 : Point, p4 : Point, t : f32) -> Point 
{
    let a : Point = line_lerp(p1, p2, t);
    let b : Point = line_lerp(p2, p3, t);
    let c : Point = line_lerp(p3, p4, t);

    let d : Point = line_lerp(a, b, t);
    let e : Point = line_lerp(b, c, t);

    return line_lerp(d, e, t);
}

/*
    Testing
*/
fn main() 
{
    let p1 = Point { x : 10, y : 20};
    let p2 = Point { x : 20, y : 5};
    let p3 = Point { x : 30, y : 10};
    let p3 = Point { x : 40, y : 50};

    //Quadratic Bezier
    for t in 0..100 
    {
        let t = t as f32 * 0.01;
        Point bezierPoint = quadratic_bezier(p1, p2, p3, t);

        //Drawing bezierPoint for each iteration will result in a quadratic bezier curve
    }

    //Quadratic Bezier
    for t in 0..100 
    {
        let t = t as f32 * 0.01;
        Point bezierPoint = cubic_bezier(p1, p2, p3, p4, t);

        //Drawing bezierPoint for each iteration will result in a quadratic bezier curve
    }
}