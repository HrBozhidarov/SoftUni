import java.util.Arrays;
import java.util.Scanner;

public class IntersectionOfCircles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double[] firstCoordinate = Arrays.stream(scanner.nextLine().split(" "))
                .mapToDouble(Double::parseDouble)
                .toArray();
        double[] secondCoordinate = Arrays.stream(scanner.nextLine().split(" "))
                .mapToDouble(Double::parseDouble)
                .toArray();

        double x1 = firstCoordinate[0];
        double y1 = firstCoordinate[1];
        double r1 = firstCoordinate[2];
        double x2 = secondCoordinate[0];
        double y2 = secondCoordinate[1];
        double r2 = secondCoordinate[2];

        Point pointsForFirstCircle = new Point(x1, y1);
        Circle circle1 = new Circle(pointsForFirstCircle, r1);

        Point pointsForSecondCircle = new Point(x2, y2);
        Circle circle2 = new Circle(pointsForSecondCircle, r2);

        if (intersect(circle1, circle2)) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }

    private static boolean intersect(Circle circle1, Circle circle2) {
        double sumOfRadius = circle1.getRadius() + circle2.getRadius();
        double distance = Math.sqrt(Math.pow((circle1.getCenter().getX() - circle2.getCenter().getX()), 2.0)
                + Math.pow((circle1.getCenter().getY() - circle2.getCenter().getY()), 2.0));

        if (distance <= sumOfRadius) {
            return true;
        }

        return false;
    }
}

class Circle {
    private Point center;
    private double radius;

    public Circle(Point point, double radius) {
        this.center = point;
        this.radius = radius;
    }

    public double getRadius() {
        return this.radius;
    }

    private void setRadius(double radius) {
        this.radius = radius;
    }

    public Point getCenter() {
        return this.center;
    }

    private void setCenter(Point center) {
        this.center = center;
    }
}

class Point {
    private double x;
    private  double y;

    public Point(double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return this.x;
    }

    private void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return this.y;
    }

    private void setY(double y) {
        this.y = y;
    }
}
