import java.util.*;
import java.util.stream.Collectors;

public class AverageGrades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        List<Student> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] line = scanner.nextLine().split(" ");
            ArrayList<Double> grades = new ArrayList<>();
            String name = line[0];

            for (int j = 1; j < line.length; j++) {
                double grade = Double.parseDouble(line[j]);
                grades.add(grade);
            }

            Student student=new Student(name,grades);
            students.add(student);
        }

        List<Student> res= students.stream()
                .filter(x -> x.getAverageGrade()>=5)
                .collect(Collectors.toList());

        Collections.sort(res, new Comparator<Student>() {

            public int compare(Student o1, Student o2) {
                String x1=((Student)o1).getName();
                String x2=((Student)o2).getName();
                int sComp=x1.compareTo(x2);

                if (sComp!=0) {
                    return sComp;
                }

                Double a1 = ((Student) o1).getAverageGrade();
                Double a2 = ((Student) o2).getAverageGrade();
                return a2.compareTo(a1);
            }
        });

        for (Student st:res) {
            System.out.printf("%s -> %.2f%n",st.getName(),st.getAverageGrade());
        }

    }
}

class Student {
    private String name;
    private List<Double> listOfGrades;
    private double averageGrade;

    public Student(String name, ArrayList<Double> listOfGrades) {
        this.name = name;
        this.listOfGrades = new ArrayList<>(listOfGrades);
        averageGrade();
    }

    public String getName() {
        return this.name;
    }

    private void setName(String name) {
        this.name = name;
    }

    public List<Double> getListOfGrades() {
        return this.listOfGrades;
    }

    private void setListOfGrades(ArrayList<Double> listOfGrades) {
        this.listOfGrades = listOfGrades;
    }

    public double getAverageGrade() {
        return this.averageGrade;
    }

    private void setAverageGrade(double averageGrade) {
        this.averageGrade = averageGrade;
    }

    private void averageGrade() {
        for (int i = 0; i < this.listOfGrades.size(); i++) {
            this.averageGrade += this.listOfGrades.get(i);
        }
        this.averageGrade /= this.listOfGrades.size();
    }
}
