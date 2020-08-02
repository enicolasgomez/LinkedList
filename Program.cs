using System;

namespace Microsoft3
{
  class Node
  {
    public int data = 0;
    public Node next = null;
    public Node ( int d )
    {
      data = d;
    }
    public Node ()
    {
      data = 0;
      next = null;
    }
    public Node Clone()
    {
      return new Node(this.data);
    }
    public override string ToString()
    {
      return data.ToString() + " >> ";
    }
  }
  class LinkedList
  {
    Node root;
    public LinkedList() { }
    public LinkedList( int r )
    {
      root = new Node(r);
    }

    public override string ToString()
    {
      string s = "";
      Node current = root;
      while (!( current is null))
      {
        s += current.ToString();
        current = current.next;
      }
      return s;
    }

    public void Add ( int d )
    {
      if (root is null)
        root = new Node(d);
      else
        Add(root, d);
    }
    private void Add ( Node n, int d )
    {
      if ( n.next is null )
        n.next = new Node(d);
      else
        Add(n.next, d);
    }

    private void AddFirst ( int d )
    {
      if (!( root is null))
      {
        Node aux = root;
        root = new Node(d);
        root.next = aux;
      }
      else
      {
        root = new Node(d);
      }
    }
    public LinkedList Clone()
    {
      Node current = root;
      LinkedList clone = new LinkedList();
      while (!(current is null))
      {
        clone.Add(current.data);
        current = current.next;
      }
      return clone;
    }

    public LinkedList Revert()
    {
      Node current = root;
      LinkedList clone = new LinkedList();

      while (!(current is null))
      {
        clone.AddFirst(current.data);
        current = current.next;
      }

      return clone;
    }

    public void Pop()
    {
      Pop(ref root);
    }

    private Node Pop(ref Node n )
    {
      if (n.next != null)
        return Pop(ref n.next);
      else
      {
        Node last = n;
        n = null;
        return last;
      }
    }

    public void MoveRight()
    {
      if (root != null)
      {
        Node last = Pop(ref root);
        AddFirst(last.data);
      }
    }

    public void MoveLeft()
    {
      if ( ( root != null ) && ( root.next != null ) )
      {
        Node first = root;
        root = root.next;
        Add(first.data);
      }
    }

    private Node Last()
    {
      Node current = root;
      Node last = null;
      while (!(current is null))
      {
        last = current ;
        current = current.next;
      }
      return last;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      LinkedList list = new LinkedList( 5 );
      list.Add(3);
      list.Add(5);
      list.Add(2);
      list.Add(1);
      list.Add(9);
      list.Add(7);
      list.Add(11);
      list.Add(17);
      Console.WriteLine(list.ToString());
      list = list.Revert();
      Console.WriteLine(list.ToString());
      list.MoveLeft();
      list.MoveLeft();
      Console.WriteLine(list.ToString());
      list.MoveRight();
      list.MoveRight();
      Console.WriteLine(list.ToString());
      Console.ReadLine();
    }
  }
}
