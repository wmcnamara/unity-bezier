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

    let p : Point = line_lerp(a, b, t);

    return p;
}

fn main() 
{

}